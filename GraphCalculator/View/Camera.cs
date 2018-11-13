using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphCalculator.Model;
using System.Drawing;

namespace GraphCalculator.View
{
    class Camera
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Camera(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        public double Left
        {
            get
            {
                return Position.x;
            }
        }

        public double Right
        {
            get
            {
                return Position.x + Size.x;
            }
        }

        public double Bottom
        {
            get
            {
                return Position.y;
            }
        }

        public double Top
        {
            get
            {
                return Position.y + Size.y;
            }
        }

        public Vector2 Center
        {
            get
            {
                return new Vector2((Left + Right) / 2, (Bottom + Top) / 2);
            }
        }

        public void Translate(Vector2 offset)
        {
            Position += offset;
        }

        public void MoveTo(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public void Zoom(Vector2 scale, Vector2 origin)
        {
            Vector2 newPosition = Vector2.Lerp(Position, Center, Vector2.One - scale);
            Vector2 offset = Vector2.Direction(Center, origin) * (Vector2.One - scale);
            MoveTo(newPosition + offset);
            Size *= scale;
        }
    }
}
