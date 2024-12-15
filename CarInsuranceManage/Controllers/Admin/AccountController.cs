using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarInsuranceManage.Database;
using CarInsuranceManage.Models;
using System.Threading.Tasks;

namespace CarInsuranceManage.Controllers.Admin
{
    public class AccountController : Controller
    {
        private readonly CarInsuranceDbContext _context;

        public AccountController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        // GET: /admin/account/profile
        [HttpGet]
        [Route("admin/account/profile")]
        public async Task<IActionResult> ProfileForAdmin()
        {
            // Lấy thông tin người dùng hiện tại (Giả sử bạn đang dùng email trong session hoặc từ cookie)
            var currentUserEmail = User.Identity.Name; // Email người dùng đang đăng nhập (nếu bạn lưu trong Cookie)
            // Lấy thông tin người dùng từ cơ sở dữ liệu
            var userInfo = await _context.Users
                                          .Where(u => u.username == currentUserEmail)
                                          .FirstOrDefaultAsync();

            if (userInfo == null)
            {
                return NotFound("User not found");
            }

            // Truyền dữ liệu vào view
            return View("~/Views/Admin/Account/Profile.cshtml", userInfo);


        }


        // Action Lock Screen, trả về view từ thư mục Admin/App
        public IActionResult Lock_Screen()
        {
            return View("~/Views/Admin/Account/Lock_Screen.cshtml");
        }

        // DELETE: /admin/account/delete/{userId}
        [HttpPost]
        [Route("admin/account/delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Xóa người dùng khỏi cơ sở dữ liệu
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login"); // Redirect to a different page, e.g., admin dashboard
        }

        // POST: /admin/account/impersonate/{userId}
        [HttpPost]
        [Route("admin/account/impersonate/{userId}")]
        public async Task<IActionResult> ImpersonateUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Set the user’s identity as the impersonated user (this could be achieved with a custom authentication middleware)
            // For simplicity, we're assuming a session-based impersonation approach.
            HttpContext.Session.SetString("ImpersonatedUser", user.username);

            // Set the impersonated user's identity
            // Note: You would need to implement impersonation logic here to sign in as the user (e.g., using cookies)

            return RedirectToAction("ProfileForAdmin    ", "Account"); // Redirect to the profile page of the impersonated user
        }
    }
}
