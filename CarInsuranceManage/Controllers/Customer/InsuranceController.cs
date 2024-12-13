using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Customer
{
    public class InsuranceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Customer/Insurance/Index.cshtml");
        }
        [HttpGet]
        public IActionResult Services()
        {
            return View("~/Views/Customer/Insurance/Services.cshtml");
        }

        [HttpGet]
        public IActionResult Bike_Detail()
        {
            return View("~/Views/Customer/Insurance/Bike_Detail.cshtml");
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
        public IActionResult Bike_Insurance()
        {
            return View("~/Views/Customer/Insurance/Bike_Insurance.cshtml");
        }
    }
}
