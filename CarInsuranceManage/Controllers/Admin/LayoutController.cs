using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Layout/Index.cshtml");  // Đường dẫn tuyệt đối đến view Index
        }
    }
}
