using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Customer
{
    public class BlogController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Customer/Blog/Index.cshtml");
        }
    }
}
