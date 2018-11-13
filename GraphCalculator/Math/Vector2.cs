using System;

namespace GraphCalculator.Model
{
    struct Vector2
    {
        public double x;
        public double y;

        #region Constructors

        public Vector2(double xy) : this(xy, xy) {  }

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 FromPolar(double angle, double length)
        {
            double x = Math.Cos(angle) * length;
            double y = Math.Sin(angle) * length;
            return new Vector2(x, y);
        }

        #endregion

        #region Values

        public double SquaredLength
        {
            get
            {
                return x * x + y * y;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(SquaredLength);
            }
        }

        public double Angle
        {
            get
            {
                return Math.Atan2(y, x);
            }
        }

        #endregion

        #region Operators

        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);

        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);

        public static Vector2 operator *(Vector2 v1, Vector2 v2) => new Vector2(v1.x * v2.x, v1.y * v2.y);

        public static Vector2 operator /(Vector2 v1, Vector2 v2) => new Vector2(v1.x / v2.x, v1.y / v2.y);

        public static Vector2 operator -(Vector2 v) => new Vector2(-v.x, -v.y);

        public static Vector2 operator *(Vector2 v, double factor) => new Vector2(v.x * factor, v.y * factor);

        public static Vector2 operator /(Vector2 v, double factor) => new Vector2(v.x / factor, v.y / factor);

        public static Vector2 operator *(double factor, Vector2 v) => new Vector2(factor * v.x, factor * v.y);

        public static Vector2 operator /(double factor, Vector2 v) => new Vector2(factor / v.x, factor / v.y);

        #endregion

        #region Static Methods

        public static double AngleBetween(Vector2 v1, Vector2 v2)
        {
            return Math.Abs(v1.Angle - v2.Angle);
        }

        public static Vector2 Lerp(Vector2 v1, Vector2 v2, Vector2 t)
        {
            return v1 + t * (v2 - v1);
        }

        public static Vector2 Direction(Vector2 v1, Vector2 v2)
        {
            return v2 - v1;
        }

        #endregion

        #region Constants

        public static readonly Vector2 One = new Vector2(1, 1);

        public static readonly Vector2 Zero = new Vector2(0);

        public static readonly Vector2 OneX = new Vector2(1, 0);

        public static readonly Vector2 OneY = new Vector2(0, 1);

        #endregion

        public override string ToString()
        {
            return $"x={x} y={y}";
        }
    }
}
