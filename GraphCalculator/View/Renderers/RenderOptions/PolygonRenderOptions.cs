using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCalculator.View.Renderers.RenderOptions
{
    struct PolygonRenderOptions : IRenderOptions
    {
        public float BorderWidth { get; set; }
        public Color Color { get; set; }
        public bool DoFill { get; set; }
        public Color FillColor { get; set; }
        
        public PolygonRenderOptions(Color color, float borderWidth, bool doFill, Color fillColor)
        {
            Color = color;
            BorderWidth = borderWidth;
            DoFill = doFill;
            FillColor = fillColor;
        }

        public PolygonRenderOptions(Color color, float borderWidth) : this(color, borderWidth, false, Color.Empty) { }
        public PolygonRenderOptions(Color color) : this(color, 1, false, Color.Empty) { }
        public PolygonRenderOptions(Color color, bool fill) : this(color, 1, fill, color) { }
    }
}
