using VR.Triangle.Common.Entities;

namespace VR.Triangle.Common.Contract
{
    public interface IGeometryService
    {
        CalculationResult SquareOfRightTriangle(double sideA, double sideB, double sideC);
    }
}
