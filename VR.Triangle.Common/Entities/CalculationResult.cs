using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VR.Triangle.Common.Entities
{
  public class CalculationResult
    {
        public string Message    { get; set; }
        public double? Result    { get; set; }
        public ResultState State { get; set; }
    }

    public enum ResultState
    {
        IncorrectParams, NotRightTriangle, Ok
    }
}
