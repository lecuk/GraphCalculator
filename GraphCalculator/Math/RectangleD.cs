using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCalculator.Model
{
    struct RectangleD
    {
        public Vector2 position;
        public Vector2 size;

        public RectangleD(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }

        public double Left
        {
            get
            {
                return position.x;
            }
        }

        public double Right
        {
            get
            {
                return position.x + size.x;
            }
        }

        public double Bottom
        {
            get
            {
                return position.y;
            }
        }

        public double Top
        {
            get
            {
                return position.y + size.y;
            }
        }

        public Vector2 TopLeft
        {
            get
            {
                return new Vector2(Left, Top);
            }
        }
        public Vector2 TopRight
        {
            get
            {
                return new Vector2(Right, Top);
            }
        }
        public Vector2 BottomLeft
        {
            get
            {
                return new Vector2(Left, Bottom);
            }
        }
        public Vector2 BottomRight
        {
            get
            {
                return new Vector2(Right, Bottom);
            }
        }

        public Vector2 Center
        {
            get
            {
                return (BottomLeft + TopRight) / 2;
            }
        }

    }
}
