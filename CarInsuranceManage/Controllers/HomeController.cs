using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarInsuranceManage.Controllers
{
    public class HomeController : Controller
    {
        // Khai báo biến _context kiểu CarInsuranceDbContext
        private readonly CarInsuranceDbContext _context;

        // Constructor để inject CarInsuranceDbContext vào controller
        public HomeController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Lấy danh sách các dịch vụ có trạng thái "active"
            var services = await _context.services
                .Where(s => s.status == true)
                .ToListAsync();

            // Truyền danh sách dịch vụ vào ViewData
            ViewData["Services"] = services;

            // Kiểm tra quyền của người dùng và trả về view tương ứng
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            if (userRole == "admin")
            {
                return View("~/Views/Admin/Home/Index.cshtml");
            }

            return View("~/Views/Customer/Home/Index.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            // Lấy tất cả bình luận của khách hàng
            var comments = await _context.comments
                .Include(c => c.Customer)   // Lấy dữ liệu của khách hàng
                .ThenInclude(c => c.User)   // Lấy thông tin người dùng từ Customer
                .Where(c => c.status == "Active")  // Chỉ lấy các bình luận có trạng thái "Active"
                .OrderByDescending(c => c.created_at)  // Sắp xếp bình luận theo thời gian tạo
                .ToListAsync();

            if (userRole == "admin")
            {
                return View("~/Views/Admin/Home/Dashboard.cshtml", comments);  // Truyền dữ liệu vào view
            }

            // Redirect về trang mặc định cho khách hàng nếu không phải admin
            return RedirectToAction("Index", "Home");
        }

    }
}
