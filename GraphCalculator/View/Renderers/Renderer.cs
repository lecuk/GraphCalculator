using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using GC = GraphCalculator.Model;

namespace GraphCalculator.View.Renderers
{
    class Renderer
    {
        public readonly GLControl ContainerControl;
        public Renderer(GLControl containerControl)
        {
            ContainerControl = containerControl;
        }

        public Vector2d ToGL(GC.Vector2 origin)
        {
            return new Vector2d(origin.x, origin.y);
        }
    }
}
