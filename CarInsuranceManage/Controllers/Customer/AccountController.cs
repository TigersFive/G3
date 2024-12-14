using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Database;
using CarInsuranceManage.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarInsuranceManage.Controllers.Customer
{
    public class AccountController : Controller
    {
        private readonly CarInsuranceDbContext _context;

        public AccountController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login_phone()
        {
            return View("~/Views/Customer/Account/Login_Phone.cshtml");
        }

        [HttpGet]
        public IActionResult Verify_phone()
        {
            return View("~/Views/Customer/Account/Verify_phone.cshtml");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Customer/Account/Login.cshtml");
        }

        [HttpGet]
        public IActionResult Forgot_Password()
        {
            return View("~/Views/Customer/Account/Forgot_Password.cshtml");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Customer/Account/Register.cshtml");
        }

        [HttpGet]
        public IActionResult Blog()
        {
            return View("~/Views/Customer/Account/Blog.cshtml");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Warning"] = "You must be logged in to view your profile.";
                return RedirectToAction("Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.username == User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            return View("~/Views/Customer/Account/Profile.cshtml", user);
        }

        [HttpPost]
        public IActionResult Profile(User updatedUser)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Warning"] = "You must be logged in to view your profile.";
                return RedirectToAction("Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.username == User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            user.full_name = updatedUser.full_name;
            user.email = updatedUser.email;
            user.phone_number = updatedUser.phone_number;
            user.address = updatedUser.address;
            user.password = updatedUser.password;

            _context.SaveChanges();

            TempData["Success"] = "Profile updated successfully.";
            return View("~/Views/Customer/Account/Profile.cshtml", user);
        }

        [HttpGet]
        public IActionResult Info_Insurance()
        {
            return View("~/Views/Customer/Account/Info_Insurance.cshtml");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}