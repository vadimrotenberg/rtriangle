using Microsoft.VisualStudio.TestTools.UnitTesting;
using VR.Triangle.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VR.Triangle.Common.Implementation.Tests
{
  
    [TestClass()]
    public class GeometryServiceTests
    {
        private GeometryService service = new GeometryService();
        [TestMethod()]
        public void NegativeParametersMustFails()
        {
          var res =  service.SquareOfRightTriangle(-1, 2, 3);
            Assert.AreEqual(res.Result, null);
            Assert.AreEqual(res.State, Entities.ResultState.IncorrectParams);
            Assert.AreEqual(res.Message, MsgResource.IncorrectSides);
        }

        [TestMethod()]
        public void IncorrectParametersMustFails()
        {
            var res = service.SquareOfRightTriangle(1, 2, 3);
            Assert.AreEqual(res.Result, null);
            Assert.AreEqual(res.State, Entities.ResultState.NotRightTriangle);
            Assert.AreEqual(res.Message, MsgResource.NotRightTriangle);
        }

        [TestMethod()]
        public void ToBigParametersMustFails()
        {
            var res = service.SquareOfRightTriangle(double.MaxValue , double.MaxValue ,  Math.Sqrt(Math.Pow(double.MaxValue,2)+ Math.Pow(double.MaxValue, 2)));
            Assert.AreEqual(res.Result, null);
            Assert.AreEqual(res.State, Entities.ResultState.IncorrectParams);
            Assert.AreEqual(res.Message, MsgResource.ToBigTriangle);
        }

        [TestMethod()]
        public void CanCAlculateRightTriangle()
        {
            var res = service.SquareOfRightTriangle(3, 4, 5);
            Assert.AreEqual(res.Result, ( 3 * 4 ) / 2 );
            Assert.AreEqual(res.State, Entities.ResultState.Ok);
            Assert.AreEqual(res.Message, null);
        }
    }
}