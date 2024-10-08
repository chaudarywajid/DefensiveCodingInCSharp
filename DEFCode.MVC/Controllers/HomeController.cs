using DEFCode.DL;
using DEFCode.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEFCode.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vehicle = new Vehicle();
            string tareWeight = "3.5", grossWeight = "8.7"; //tonnes
            double calculatedNetWeight = 0.0;            

            try
            {

                calculatedNetWeight = vehicle.CalculateWeight(tareWeight, grossWeight);

            }
            catch (ArgumentException ex)
            {

                Debug.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

            }


            //try
            //{
            //    calculatedNetWeight = vehicle.CalculateWeight(tareWeight, grossWeight);

            //}
            //catch (ValidationException ex) when (ex.ParamName == "tareweight")
            //{

            //    //Display a validation error message on the tareweight field

            //}
            //catch (ValidationException ex) when (ex.ParamName == "grossweight")
            //{

            //    //Display a validation error message on the grossweight field

            //}

            ViewBag.calculatedNetWeight = calculatedNetWeight;

            return View();
        }
      
    }
}