using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK = OpenTK;
using OpenTK.Graphics.OpenGL;
using GraphCalculator.Model;
using GraphCalculator.View.Renderers.RenderOptions;

namespace GraphCalculator.View.Renderers
{
    class PrimitiveRenderer : Renderer
    {
        public const int CIRCLE_VERTEX_COUNT = 32;

        public PrimitiveRenderer(TK.GLControl containerControl) : base(containerControl)
        {

        }

        public void Line(Vector2 from, Vector2 to, LineRenderOptions options)
        {
            GL.Enable(EnableCap.LineSmooth);
            GL.LineWidth(options.Width);
            GL.Color4(options.Color);

            GL.Begin(PrimitiveType.Lines);

            GL.Vertex2(ToGL(from));
            GL.Vertex2(ToGL(to));

            GL.End();
            GL.Disable(EnableCap.LineSmooth);
        }

        public void Lines(IEnumerable<Vector2> points, PrimitiveType renderMode, LineRenderOptions options)
        {
            GL.Enable(EnableCap.LineSmooth);
            GL.LineWidth(options.Width);
            GL.Color4(options.Color);

            GL.Begin(renderMode);
            
            foreach(Vector2 point in points)
            {
                GL.Vertex2(ToGL(point));
            }

            GL.End();
            GL.Disable(EnableCap.LineSmooth);
        }

        public void Polygon(Vector2 center, double radius, double angle, int vertexCount, PolygonRenderOptions options)
        {
            double vertexAngle = Math.PI / vertexCount;

            if (options.DoFill)
            {
                GL.Enable(EnableCap.LineSmooth);
                GL.LineWidth(options.BorderWidth);
                GL.Color4(options.FillColor);
                GL.Begin(PrimitiveType.Polygon);

                for (int i = 0; i < vertexCount; i++)
                {
                    Vector2 point = Vector2.FromPolar(angle + i * vertexAngle, radius);
                    GL.Vertex2(ToGL(point));
                }

                GL.End();
            }

            GL.LineWidth(options.BorderWidth);
            GL.Color4(options.Color);
            GL.Begin(PrimitiveType.LineLoop);

            for (int i = 0; i < vertexCount; i++)
            {
                Vector2 point = Vector2.FromPolar(angle + i * vertexAngle, radius);
                GL.Vertex2(ToGL(point));
            }

            GL.End();
            GL.Disable(EnableCap.LineSmooth);
        }

        public void Circle(Vector2 center, double radius, PolygonRenderOptions options)
        {
            Polygon(center, radius, 0, CIRCLE_VERTEX_COUNT, options);
        }

        public void Point(Vector2 point, PointRenderOptions options)
        {
            GL.Enable(EnableCap.PointSmooth);
            GL.Color4(options.Color);
            GL.PointSize(options.Width);
            GL.Begin(PrimitiveType.Points);

            GL.Vertex2(ToGL(point));

            GL.End();
            GL.Disable(EnableCap.PointSmooth);
        }

        public void Points(IEnumerable<Vector2> points, PointRenderOptions options)
        {
            GL.Enable(EnableCap.PointSmooth);
            GL.Color4(options.Color);
            GL.PointSize(options.Width);
            GL.Begin(PrimitiveType.Points);

            foreach (Vector2 point in points)
            {
                GL.Vertex2(ToGL(point));
            }

            GL.End();
            GL.Disable(EnableCap.PointSmooth);
        }
    }
}
