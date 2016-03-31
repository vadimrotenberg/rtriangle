using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VR.Triangle.WebUI.Models
{
    public class TriangleModel
    {
        [Display(Name = "Первая сторона"), Required(ErrorMessage = "{0} не задана")]
        public double? SideA { get; set; }

        [Display(Name = "Вторая сторона"), Required(ErrorMessage = "{0} не задана")]
        public double? SideB { get; set; }

        [Display(Name = "Третья сторона"), Required(ErrorMessage = "{0} не задана")]
        public double? SideC  { get; set; }

        [Display(Name ="Площадь")]
        public double? Square {get;set;}
    }
}