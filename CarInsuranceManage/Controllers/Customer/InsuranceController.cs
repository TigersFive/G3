using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Customer
{
    public class InsuranceController : Controller
    {

        [HttpGet]
        public IActionResult Services()
        {
            return View("~/Views/Customer/Insurance/Services.cshtml");
        }

        [HttpGet]
        public IActionResult Moto_Detail()
        {
            return View("~/Views/Customer/Insurance/Moto_Detail.cshtml");
        }
        [HttpGet]
        public IActionResult Moto_Insurance()
        {
            return View("~/Views/Customer/Insurance/Moto_Insurance.cshtml");
        }
        [HttpGet]
        public IActionResult Car_Detail()
        {
            return View("~/Views/Customer/Insurance/Car_Detail.cshtml");
        }
        [HttpGet]
        public IActionResult Car_Insurance()
        {
            return View("~/Views/Customer/Insurance/Car_Insurance.cshtml");
        }
        [HttpGet]
        public IActionResult Truck_Detail()
        {
            return View("~/Views/Customer/Insurance/Truck_Detail.cshtml");
        }
        [HttpGet]
        public IActionResult Truck_Insurance()
        {
            return View("~/Views/Customer/Insurance/Truck_Insurance.cshtml");
        }
    }
}
