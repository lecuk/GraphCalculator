using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using GraphCalculator.Model;
using OpenTK.Graphics.OpenGL;
using GraphCalculator.View.Renderers;
using GraphCalculator.View.Renderers.RenderOptions;

namespace GraphCalculator.Model
{
    class FunctionGraph
    {
        public PostfixFunction Function { get; set; }
        public Color Color { get; set; }
        public float Width { get; set; }
        public bool Enabled { get; set; }
        public bool Selected { get; set; }

        public FunctionGraph(PostfixFunction function, Color color, float width)
        {
            Function = function;
            Color = color;
            Width = width;
            Enabled = true;
        }
    }
}
