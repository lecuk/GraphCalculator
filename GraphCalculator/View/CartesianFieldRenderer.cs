using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraphCalculator.Model;
using TK = OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using GraphCalculator.View.Renderers;
using GraphCalculator.View.Forms;
using GraphCalculator.View.Renderers.RenderOptions;

namespace GraphCalculator.View
{
    class CartesianFieldRenderer
    {
        readonly TK.GLControl RenderControl;
        readonly CartesianField Field;

        public const double CellSizeToFieldOfViewComparision = 0.2;

        public static readonly LineRenderOptions AXIS_LINE_RENDER_OPTIONS = new LineRenderOptions(Color.WhiteSmoke, 2.0f);
        public static readonly LineRenderOptions MAJOR_CELL_BORDER_RENDER_OPTIONS = new LineRenderOptions(Color.FromArgb(100, 100, 100), 1.0f);
        public static readonly LineRenderOptions MINOR_CELL_BORDER_RENDER_OPTIONS = new LineRenderOptions(Color.FromArgb(25, 25, 25), 0.5f);

        const double ZoomPower = 1.2;
        private Camera FieldOfView;

        readonly PrimitiveRenderer P_Renderer;
        
        public void Render()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(FieldOfView.Left, FieldOfView.Right, FieldOfView.Bottom, FieldOfView.Top, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            
            DrawGrid();

            foreach (FunctionGraph graph in Field.Graphs)
            {
                DrawGraph(graph);
            }
        }

        void DrawGraph(FunctionGraph graph)
        {
            if (graph.Enabled && graph.Function.IsValid)
            {
                Curve curve = graph.Function.PlotFunction(FieldOfView.Left, FieldOfView.Right);
                P_Renderer.Lines(curve.Nodes, PrimitiveType.LineStrip, new LineRenderOptions(graph.Color, graph.Width));
                //renderer.Points(curve.Nodes, new PointRenderOptions(Color.White, Width * 1f));
            }
        }

        void DrawGrid()
        {
            Vector2 major = GetMajorCellSize();
            Vector2 minor = GetMinorCellSize();

            double Xmj = FieldOfView.Right - FieldOfView.Right % major.x;
            double Ymj = FieldOfView.Top - FieldOfView.Top % major.y;
            double Xmn = FieldOfView.Right - FieldOfView.Right % minor.x;
            double Ymn = FieldOfView.Top - FieldOfView.Top % minor.y;

            List<Vector2> xMajorLines = new List<Vector2>(16), yMajorLines = new List<Vector2>(16);
            List<Vector2> xMinorLines = new List<Vector2>(128), yMinorLines = new List<Vector2>(128);

            double x = Xmn;
            while (x >= FieldOfView.Left)
            {
                xMinorLines.Add(new Vector2(x, FieldOfView.Bottom));
                xMinorLines.Add(new Vector2(x, FieldOfView.Top));
                x -= minor.x;
            }

            double y = Ymn;
            while (y >= FieldOfView.Bottom)
            {
                yMinorLines.Add(new Vector2(FieldOfView.Left, y));
                yMinorLines.Add(new Vector2(FieldOfView.Right, y));
                y -= minor.y;
            }

            x = Xmj;
            while (x >= FieldOfView.Left)
            {
                xMajorLines.Add(new Vector2(x, FieldOfView.Bottom));
                xMajorLines.Add(new Vector2(x, FieldOfView.Top));
                x -= major.x;
            }

            y = Ymj;
            while (y >= FieldOfView.Bottom)
            {
                yMajorLines.Add(new Vector2(FieldOfView.Left, y));
                yMajorLines.Add(new Vector2(FieldOfView.Right, y));
                y -= major.y;
            }

            P_Renderer.Lines(xMinorLines, PrimitiveType.Lines, MINOR_CELL_BORDER_RENDER_OPTIONS);
            P_Renderer.Lines(yMinorLines, PrimitiveType.Lines, MINOR_CELL_BORDER_RENDER_OPTIONS);
            P_Renderer.Lines(xMajorLines, PrimitiveType.Lines, MAJOR_CELL_BORDER_RENDER_OPTIONS);
            P_Renderer.Lines(yMajorLines, PrimitiveType.Lines, MAJOR_CELL_BORDER_RENDER_OPTIONS);

            P_Renderer.Line(new Vector2(0, FieldOfView.Bottom), new Vector2(0, FieldOfView.Top), AXIS_LINE_RENDER_OPTIONS);
            P_Renderer.Line(new Vector2(FieldOfView.Left, 0), new Vector2(FieldOfView.Right, 0), AXIS_LINE_RENDER_OPTIONS);
        }

        public Vector2 GetMajorCellSize()
        {
            double scale = Math.Pow(2, Math.Round(Math.Log(Math.Min(FieldOfView.Size.x, FieldOfView.Size.y) * CellSizeToFieldOfViewComparision, 2)));
            return new Vector2(scale);
        }

        public Vector2 GetMinorCellSize()
        {
            return GetMajorCellSize() / 5;
        }

        public void MoveCamera(Vector2 offset)
        {
            FieldOfView.Translate(offset);
        }

        public void SetCameraBounds(RectangleD newBounds)
        {
            FieldOfView.Position = newBounds.position;
            FieldOfView.Size = newBounds.size;
        }

        public void ChangeFOW(Size oldScreenSize, Size newScreenSize)
        {
            double x = (double)newScreenSize.Width / oldScreenSize.Width;
            double y = (double)newScreenSize.Height / oldScreenSize.Height;
            Vector2 newSize = FieldOfView.Size * new Vector2(x, y);
            FieldOfView.Size = newSize;
        }

        public void ZoomIn(Vector2 origin)
        {
            FieldOfView.Zoom(new Vector2(1.0 / ZoomPower), origin);
        }

        public void ZoomOut(Vector2 origin)
        {
            FieldOfView.Zoom(new Vector2(ZoomPower), origin);
        }
        
        public Vector2 ScreenToWorld(Point mousePosition, Size screenSize)
        {
            double x = (double)mousePosition.X / screenSize.Width;
            double y = 1.0 - (double)mousePosition.Y / screenSize.Height;
            return new Vector2(x, y) * FieldOfView.Size + FieldOfView.Position;
        }

        public Vector2 ScreenToOffset(Point mouseOffset, Size screenSize)
        {
            double x = (double)mouseOffset.X / screenSize.Width;
            double y = -(double)mouseOffset.Y / screenSize.Height;
            return new Vector2(x, y) * FieldOfView.Size;
        }

        public CartesianFieldRenderer(CartesianField field, FieldRendererControl renderControl)
        {
            Field = field;
            RenderControl = renderControl;

            FieldOfView = new Camera(new Vector2(-5, -5), new Vector2(10, 10));
            P_Renderer = new PrimitiveRenderer(renderControl);
        }
    }
}
