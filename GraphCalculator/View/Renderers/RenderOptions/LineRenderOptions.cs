using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphCalculator.Model;

namespace GraphCalculator.View.Renderers.RenderOptions
{
    struct LineRenderOptions : IRenderOptions
    {
        public Color Color { get; set; }
        public float Width { get; set; }

        public LineRenderOptions(Color color, float width)
        {
            Color = color;
            Width = width;
        }

        public LineRenderOptions(Color color) : this(color, 1) { }
    }
}
