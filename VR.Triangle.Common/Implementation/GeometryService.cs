using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VR.Triangle.Common.Contract;
using VR.Triangle.Common.Entities;

namespace VR.Triangle.Common.Implementation
{
    public class GeometryService : IGeometryService
    {
        public CalculationResult SquareOfRightTriangle(double sideA, double sideB, double sideC)
        {

            Entities.Triangle triangle = null;
            var result = new CalculationResult();
            try
            {
                triangle   = new Entities.Triangle(sideA, sideB, sideC);
                result.State = ResultState.Ok;
            }
            catch(InvalidTriangleException tex)
            {
                switch (tex.state)
                {
                    case ValidationResult.InvalidSides:
                        result.State  = ResultState.IncorrectParams;
                        result.Message = MsgResource.IncorrectSides;
                        break;
                     
                    case ValidationResult.NotRightTriangle:
                        result.State   = ResultState.NotRightTriangle;
                        result.Message = MsgResource.NotRightTriangle;
                        break;
                }
            }
            if (result.State == ResultState.Ok)
            {
                var sides = new[] { triangle.sideA, triangle.sideB, triangle.sideC };
                var maxSide = sides.Max();
                if (sides.Sum(s => Math.Pow(s, 2)) > double.MaxValue)
                {
                    result.State = ResultState.IncorrectParams;
                    result.Message = MsgResource.ToBigTriangle;
                }
                else
                {
                    result.State = ResultState.Ok;
                    var twoSides = sides.Where(s => s != maxSide).ToArray();
                    result.Result = twoSides[0] * twoSides[1] / 2.0;
                }
            }
            return result;
        }
    }
}
