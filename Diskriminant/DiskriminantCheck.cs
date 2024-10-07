using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diskriminant
{
    public class MathOperations
    {
        public static double[] FindRoots(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return new double[0]; 
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return new double[] { root }; 
            }
            else
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double root1 = (-b + sqrtDiscriminant) / (2 * a);
                double root2 = (-b - sqrtDiscriminant) / (2 * a);
                return new double[] { root1, root2 }; 
            }
        }

        public static double CalculatePercentage(double number, double percentage)
        {
            return number * (percentage / 100);
        }
    }
}