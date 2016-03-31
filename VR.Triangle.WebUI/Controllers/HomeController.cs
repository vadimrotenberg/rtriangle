using System.Web.Mvc;
using VR.Triangle.Common.Contract;
using VR.Triangle.WebUI.Models;

namespace VR.Triangle.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeometryService _geometryService;
        public HomeController(IGeometryService geometryService)
        {
            _geometryService = geometryService;
        }

        public ViewResult Index(double? square, double? sidea, double? sideb, double? sidec)
        {
            return View(  new TriangleModel() { Square = square, SideA=sidea, SideB=sideb, SideC=sidec });
        }

        [HttpPost]
        public ActionResult Index(TriangleModel triangle)
        {
            if (ModelState.IsValid)
            {
                var result = _geometryService.SquareOfRightTriangle(triangle.SideA.Value, triangle.SideB.Value, triangle.SideC.Value);
                triangle.Square = result.Result;

                if (result.State != Common.Entities.ResultState.Ok)
                  ModelState.AddModelError("", result.Message);
                
                if (ModelState.IsValid)
                 return RedirectToAction("Index", triangle);
           }
          return View("Index",triangle);
        }
    }
}