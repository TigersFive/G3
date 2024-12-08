using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Claim = System.Security.Claims.Claim;
using Microsoft.AspNetCore.Authentication.Facebook;

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
        public IActionResult Login()
        {
            return View("~/Views/Customer/Account/Login.cshtml");
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
                new Claim(ClaimTypes.Role, user.user_logs ?? "user") // Default role
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

        public IActionResult LoginWithGoogle()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        // Action to initiate login with Facebook
        public IActionResult LoginWithFacebook()
        {
            var redirectUrl = Url.Action("FacebookResponse", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
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
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result?.Principal != null)
            {
                var claims = result.Principal.Identities.FirstOrDefault()?.Claims.Select(claim => new { claim.Type, claim.Value });
                var email = claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                var name = claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

                if (email == null || name == null)
                {
                    return RedirectToAction("Login");
                }

                var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
                if (user == null)
                {
                    user = new User
                    {
                        username = name,
                        email = email,
                        user_logs = "Facebook", // Store Facebook login type
                        password = "N/A",
                        address = "N/A",
                        created_at = DateTime.Now,
                        role = "user"
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }

                var loginLog = new LoginLog
                {
                    user_id = user.user_id,
                    ip_address = HttpContext.Connection.RemoteIpAddress?.ToString(),
                    login_time = DateTime.Now
                };

                _context.LoginLogs.Add(loginLog);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        public IActionResult Forgot_Password()
        {
            return View("~/Views/Customer/Account/Forgot_Password.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
            if (user == null)
            {
                // Email không tồn tại trong cơ sở dữ liệu
                ModelState.AddModelError("", "Email không tồn tại.");
                return View("~/Views/Customer/Account/ForgotPassword.cshtml");
            }

            if (user.user_logs == "Google")
            {
                // Người dùng đăng nhập bằng Google, thông báo rằng họ không cần mật khẩu
                ModelState.AddModelError("", "Bạn đã đăng nhập bằng Google, vui lòng sử dụng đăng nhập Google để truy cập tài khoản.");
                return View("~/Views/Customer/Account/ForgotPassword.cshtml");
            }
            else
            {
                // Gửi liên kết đặt lại mật khẩu qua email
                // Logic gửi email đặt lại mật khẩu
                // ...
                TempData["Message"] = "Liên kết đặt lại mật khẩu đã được gửi đến email của bạn.";
                return RedirectToAction("Login");
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Customer/Account/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string username, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "All fields are required.");
                return View("~/Views/Customer/Account/Register.cshtml");
            }

            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View("~/Views/Customer/Account/Register.cshtml");
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Email already exists.");
                return View("~/Views/Customer/Account/Register.cshtml");
            }

            var user = new User
            {
                username = username,
                email = email,
                password = password, // Lưu trực tiếp mật khẩu
                created_at = DateTime.Now,
                user_logs = "Email",
                role = "user"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Registration successful. Please login.";
            return RedirectToAction("Login");
        }
        public IActionResult Blog()
        {
            return View("~/Views/Customer/Account/Blog.cshtml");
        }
        public IActionResult Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Warning"] = "You must be logged in to view your profile.";
                return RedirectToAction("Login");
            }
            return View("~/Views/Customer/Account/Profile.cshtml");
        }

        public IActionResult Info_Insurance()
        {
            return View("~/Views/Customer/Account/Info_Insurance.cshtml");
        }
    }
}