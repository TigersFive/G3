using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Customer
{
    public class InsuranceController : Controller
    {

         public IActionResult Services()
        {
            return View("~/Views/Customer/Insurance/Services.cshtml");
        }
        public IActionResult Bike_Detail()
        {
            return View("~/Views/Customer/Insurance/Bike_Detail.cshtml");
        }
         
         public IActionResult Car_Detail()
        {
            return View("~/Views/Customer/Insurance/Car_Detail.cshtml");
        }

         public IActionResult Car_Insurance()
        {
            return View("~/Views/Customer/Insurance/Car_Insurance.cshtml");
        }

         public IActionResult Bike_Insurance()
        {
            return View("~/Views/Customer/Insurance/Bike_Insurance.cshtml");
        }
    }
}
