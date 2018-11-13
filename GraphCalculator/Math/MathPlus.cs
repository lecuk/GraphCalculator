using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCalculator.Model
{
    static class MathPlus
    {
        public static double Factorial(double x)
        {
            if (x < 0) return double.NaN;

            double product = 1;
            for (double i = 2; i < Math.Floor(x); i += 1)
            {
                product *= i;
            }

            return product;
        }

        public static double[] Interpolate(double a, double b, int count)
        {
            double[] values = new double[count];

            for (int i = 0; i < count; i++)
            {
                double x = a + (b - a) * i / (count - 1);
                values[i] = x;
            }

            return values;
        }

        public static double Lerp(double a, double b, double t)
        {
            return a + t * (b - a);
        }

        public static double GetLerpT(double a, double b, double value)
        {
            return (value - a) / (b - a);
        }
    }
}
