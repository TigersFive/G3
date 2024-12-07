using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class PageController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Admin/Page/Login.cshtml");  // Đường dẫn tuyệt đối đến view Login
        }

        public IActionResult Register()
        {
            return View("~/Views/Admin/Page/Register.cshtml");  // Đường dẫn tuyệt đối đến view Register
        }

        public IActionResult Lock_Screen()
        {
            return View("~/Views/Admin/Page/Lock_Screen.cshtml");  // Đường dẫn tuyệt đối đến view Lock_Screen
        }

        public IActionResult Not_Found()
        {
            return View("~/Views/Admin/Page/Not_Found.cshtml");  // Đường dẫn tuyệt đối đến view Not_Found
        }
    }
}
