﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarInsuranceManage.Controllers
{
    public class AboutController : Controller
    {
        // Khai báo biến _context kiểu CarInsuranceDbContext
        private readonly CarInsuranceDbContext _context;

        // Constructor để inject CarInsuranceDbContext vào controller
        public AboutController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()  // Add async here and return Task<IActionResult>
        {
            // Lấy danh sách các dịch vụ từ bảng Services
            var services = await _context.services
                .Where(s => s.status == true) // Lọc các dịch vụ có trạng thái "active"
                .ToListAsync();

            // Truyền dữ liệu vào ViewData
            ViewData["Services"] = services;
            return View("~/Views/Customer/About/Index.cshtml");
        }
    }
}
