using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Customer
{
    public class InsuranceController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Customer/Insurance/Index.cshtml");
        }
          public IActionResult Services()
        {
            return View("~/Views/Customer/Insurance/Services.cshtml");
        }
    }
}
