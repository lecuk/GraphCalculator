using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace GraphCalculator.View.Renderers
{
    class TextureRenderer : Renderer
    {
        public TextureRenderer(GLControl renderControl) : base(renderControl)
        {

        }

        public void DrawTexture(Texture2D texture, Model.Vector2 a, Model.Vector2 b, Model.Vector2 c, Model.Vector2 d, Color color)
        {
            GL.Color3(color);
            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex2(ToGL(a));
            GL.TexCoord2(1, 0);
            GL.Vertex2(ToGL(b));
            GL.TexCoord2(1, 1);
            GL.Vertex2(ToGL(c));
            GL.TexCoord2(0, 1);
            GL.Vertex2(ToGL(d));

            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

        public void DrawTexture(Texture2D texture, Model.RectangleD rectangle, Color color)
        {
            DrawTexture(texture, rectangle.TopLeft, rectangle.TopRight, rectangle.BottomRight, rectangle.BottomLeft, color);
        }
    }
}
