﻿using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Customer
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Customer/About/Index.cshtml");
        }
    }
}
