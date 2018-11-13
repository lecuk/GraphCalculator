using System;
using System.Collections.Generic;
using OpenTK;
using System.Diagnostics;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using GraphCalculator.Model;
using System.Windows.Forms;
using System.ComponentModel;
using GraphCalculator.View.Renderers;

namespace GraphCalculator.View.Forms
{
    class FieldRendererControl : GLControl
    {
        readonly Timer updateTimer;
        public int TicksPerFrame { get; private set; }
        public float FPS { get; private set; }
        public bool CanBeControlled { get; set; }
        
        public CartesianFieldRenderer FieldRenderer { get; set; }

        public event EventHandler OnUpdate;

        private Size lastSize;

        private Point lastLocalMousePosition;
        public Point LocalMousePosition
        {
            get
            {
                return PointToClient(MousePosition);
            }
        }

        public Model.Vector2 WorldMousePosition
        {
            get
            {
                return FieldRenderer.ScreenToWorld(LocalMousePosition, Size);
            }
        }

        public FieldRendererControl() : base() //for designer
        {
            updateTimer = new Timer();
            updateTimer.Tick += OnRenderFrame;
            lastSize = Size;
        }

        public FieldRendererControl(CartesianFieldRenderer renderer) : this()
        {
            FieldRenderer = renderer;
        }
        
        public void Run(float FPS)
        {
            if (!updateTimer.Enabled)
            {
                this.FPS = FPS;
                TicksPerFrame = (int)(1000.0 / FPS);
                updateTimer.Interval = TicksPerFrame;
                updateTimer.Start();
            }
        }

        public void Stop()
        {
            if (updateTimer.Enabled)
            {
                updateTimer.Stop();
            }
        }
        
        protected void OnRenderFrame(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                MakeCurrent();
                
                GL.Clear(ClearBufferMask.ColorBufferBit);

                FieldRenderer.Render();
                
                SwapBuffers();

                OnUpdate?.Invoke(this, new EventArgs());
            }
        }
        
        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (FieldRenderer != null && !DesignMode)
            {
                MakeCurrent();
                GL.Viewport(new Rectangle(Point.Empty, Bounds.Size));

                if (Size.Width > 0 && Size.Height > 0)
                {
                    FieldRenderer.ChangeFOW(lastSize, Size);
                    lastSize = Size;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (CanBeControlled)
            {
                if (MouseButtons.HasFlag(MouseButtons.Left))
                {
                    int x = lastLocalMousePosition.X - LocalMousePosition.X;
                    int y = lastLocalMousePosition.Y - LocalMousePosition.Y;
                    Model.Vector2 offset = FieldRenderer.ScreenToOffset(new Point(x, y), Size);
                    FieldRenderer.MoveCamera(offset);
                }
                lastLocalMousePosition = LocalMousePosition;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (CanBeControlled)
            {
                if (e.Delta > 0)
                {
                    FieldRenderer.ZoomIn(WorldMousePosition);
                }
                else
                {
                    FieldRenderer.ZoomOut(WorldMousePosition);
                }
            }
        }

        public void SetCameraBounds(RectangleD newBounds)
        {
            FieldRenderer.SetCameraBounds(newBounds);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(270, 269);
            this.ResumeLayout(false);
        }
    }
}
