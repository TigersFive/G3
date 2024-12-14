using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Claim = System.Security.Claims.Claim;

namespace CarInsuranceManage.Controllers.Customer
{
    public class LoginDBController : Controller
    {
        private readonly CarInsuranceDbContext _context;

        public LoginDBController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                TempData["WarningMessage"] = "Please enter both email and password.";
                return View("~/Views/Customer/Account/Login.cshtml");
            }

            // Check if the user exists
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
            if (user == null)
            {
                TempData["WarningMessage"] = "Invalid email or password.";
                return View("~/Views/Customer/Account/Login.cshtml");
            }

            if (user.user_logs == "Google")
            {
                TempData["WarningMessage"] = "This account uses Google login. Please use Google to log in.";
                return View("~/Views/Customer/Account/Login.cshtml");
            }

            // Validate the password
            if (user.password != password) // Replace with a secure password hash check
            {
                TempData["WarningMessage"] = "Invalid email or password.";
                return View("~/Views/Customer/Account/Login.cshtml");
            }

            // Create claims for the user
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim(ClaimTypes.Role, user.role == "admin" ? "admin" : "user")

                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Enable "Remember Me" functionality
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            // Log the login action
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var loginLog = new LoginLog
            {
                user_id = user.user_id,
                ip_address = ipAddress,
                login_time = DateTime.Now
            };

            _context.LoginLogs.Add(loginLog);
            await _context.SaveChangesAsync();

            // Redirect to home after successful login
            return RedirectToAction("Index", "Home");
        }

    }
}