using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class AppController : Controller
    {
        // Action Profile, trả về view từ thư mục Admin/App
        public IActionResult Profile()
        {
            return View("~/Views/Admin/App/Profile.cshtml");  
        }

        // Action Calendar, trả về view từ thư mục Admin/App
        public IActionResult Calendar()
        {
            return View("~/Views/Admin/App/Calendar.cshtml"); 
        }
    }
}
