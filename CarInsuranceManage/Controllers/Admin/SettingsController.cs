using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class SettingsController : Controller
    {
       public IActionResult Services()
        {
            return View("~/Views/Admin/Settings/Services.cshtml");  
        }
    }
}
