using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/User/Index.cshtml");  // Đường dẫn tuyệt đối
        }

    }
}
