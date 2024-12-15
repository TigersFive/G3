using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class SettingsController : Controller
    {
       public IActionResult Banner()
        {
            return View("~/Views/Admin/Settings/Banner.cshtml");  
        }
    }
}
