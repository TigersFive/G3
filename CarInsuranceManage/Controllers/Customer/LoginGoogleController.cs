using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace CarInsuranceManage.Controllers.Customer
{
    public class LoginGoogleController : Controller
    {
        private readonly CarInsuranceDbContext _context;

        public LoginGoogleController(CarInsuranceDbContext context)
        {
            _context = context;
        }


        

        public IActionResult LoginWithGoogle()
        {
            var redirectUrl = Url.Action("GoogleResponse", "LoginGoogle");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
     

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result?.Principal != null)
            {
                // Retrieve claims
                var claims = result.Principal.Identities.FirstOrDefault()?.Claims.Select(claim => new { claim.Type, claim.Value });
                var email = claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                var name = claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

                if (email == null || name == null)
                {
                    // If email or name is not available, redirect back to login
                    return RedirectToAction("Login");
                }

                // Check if the user already exists in the database
                var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
                if (user == null)
                {
                    // Add a new user with default values for required fields
                    user = new User
                    {
                        username = name,
                        email = email,
                        user_logs = "Google", // Indicate Google login
                        password = "N/A", // Set default value as password is not needed for Google login
                        address = "N/A", // Default value for address
                        created_at = DateTime.Now,
                        role = "user"
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }

                // Optionally, log the login action
                var loginLog = new LoginLog
                {
                    user_id = user.user_id,
                    ip_address = HttpContext.Connection.RemoteIpAddress?.ToString(),
                    login_time = DateTime.Now
                };

                _context.LoginLogs.Add(loginLog);
                await _context.SaveChangesAsync();

                // Redirect to home after successful login
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login");
        }
        // Handle Facebook login response
       
       
    }
}