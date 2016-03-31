using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VR.Triangle.Common.Entities
{
   internal sealed class Triangle
    {
        internal double sideA;
        internal double sideB;
        internal double sideC;
        private Triangle() { }
        internal Triangle(double a, double b, double c)
        {
            sideA = a;
            sideB = b;
            sideC = c;
            var state = Validate();
            if (state != ValidationResult.Ok)
                throw new InvalidTriangleException(state);
        }
        private ValidationResult Validate()
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0) return ValidationResult.InvalidSides;
            var sides   = new[] { sideA, sideB, sideC };
            var maxSide = sides.Max();
            if (sides.Count(s => s == maxSide) > 1) return ValidationResult.InvalidSides;
            if (sides.Where(s => s != maxSide).Sum(s => Math.Pow(s, 2)) == Math.Pow(maxSide, 2)) return ValidationResult.Ok;
            return ValidationResult.NotRightTriangle;
        }
     }
}
