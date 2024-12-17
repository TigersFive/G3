using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Database;
using Microsoft.EntityFrameworkCore;

namespace CarInsuranceManage.Controllers.Customer
{
    public class InsuranceController : Controller
    {
        private readonly CarInsuranceDbContext _context;

        public InsuranceController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Services()
        {
            // Lấy danh sách các dịch vụ từ bảng Services
            var services = await _context.services
                .Where(s => s.status == true) // Lọc các dịch vụ có trạng thái "active"
                .ToListAsync();
            ViewData["Services"] = services;

            return View("~/Views/Customer/Insurance/services.cshtml", services);  // Trả về danh sách dịch vụ cho view
        }

        [HttpGet]
        public async Task<IActionResult> Car_Details(int id)
        {
            // Lấy thông tin chi tiết dịch vụ từ database theo id
            var service = await _context.services
                .Include(s => s.InsurancePolicy)  // Eager loading để lấy thông tin InsurancePolicy liên quan
                .Where(s => s.id == id)
                .FirstOrDefaultAsync();

            if (service == null)
            {
                // Nếu không tìm thấy dịch vụ, trả về lỗi 404
                return NotFound();
            }

            // Kiểm tra nếu InsurancePolicy đã được load từ Include()
            if (service.InsurancePolicy == null)
            {
                ViewBag.PolicyAmount = "Không tìm thấy thông tin gói bảo hiểm.";
            }
            else
            {
                // Truyền giá trị giá tiền của gói bảo hiểm vào ViewBag để hiển thị
                ViewBag.PolicyAmount = service.InsurancePolicy.policy_amount.ToString("C2");  // Định dạng tiền tệ
            }

            // Lấy danh sách các dịch vụ từ cơ sở dữ liệu
            var services = await _context.services
                .Where(s => s.status == true)  // Lọc các dịch vụ có trạng thái "active"
                .ToListAsync();

            // Truyền danh sách các dịch vụ vào ViewData
            ViewData["Services"] = services;

            // Trả về thông tin dịch vụ cùng với gói bảo hiểm liên quan vào View
            return View("~/Views/Customer/Insurance/Car_details.cshtml", service);
        }

        [HttpGet]
        public async Task<IActionResult> Car_Insurance(int id)
        {
            var service = await _context.services
                .Where(s => s.id == id && s.status == true)
                .FirstOrDefaultAsync();

            var services = await _context.services
                .Where(s => s.status == true) // Lọc các dịch vụ có trạng thái "active"
                .ToListAsync();

            if (service == null)
            {
                return NotFound(); // Nếu không tìm thấy dịch vụ, trả về lỗi 404
            }

            // Truyền dữ liệu vào ViewData
            ViewData["Data"] = service;
            ViewData["Services"] = services;

            return View("~/Views/Customer/Insurance/Car_insurance.cshtml");
        }


    }
}
