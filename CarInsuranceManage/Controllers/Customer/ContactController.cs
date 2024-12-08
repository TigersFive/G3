using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Customer
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Customer/Contact/Index.cshtml");
        }
    }
}
