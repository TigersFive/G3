using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class EmailController : Controller
    {
        public IActionResult Inbox()
        {
            return View("~/Views/Admin/Email/Inbox.cshtml");  // Đường dẫn tuyệt đối đến view Inbox
        }

        public IActionResult Read()
        {
            return View("~/Views/Admin/Email/Read.cshtml");  // Đường dẫn tuyệt đối đến view Read
        }

        public IActionResult Compose()
        {
            return View("~/Views/Admin/Email/Compose.cshtml");  // Đường dẫn tuyệt đối đến view Compose
        }
    }
}
