using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers
{
    public class HomeController : Controller
    {
        // This is for the admin after login
        public IActionResult Index()
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            
            if (userRole == "admin")
            {
                return View("~/Views/Admin/Home/Index.cshtml");
            }
            
            // Default to customer view if not an admin
            return View("~/Views/Customer/Home/Index.cshtml");
        }

        public IActionResult Dashboard()
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            
            if (userRole == "admin")
            {
                return View("~/Views/Admin/Home/Dashboard.cshtml");
            }

            // If not an admin, redirect to a default page or show an error
            return RedirectToAction("Index", "Home");
        }
        
        // For the customer (non-admin) page
        public IActionResult Privacy()
        {
            return View("~/Views/Customer/Home/Privacy.cshtml");
        }
    }
}
