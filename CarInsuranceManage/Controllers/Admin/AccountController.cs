﻿using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class AccountController : Controller
    {
       public IActionResult Profile()
        {
            return View("~/Views/Admin/App/Profile.cshtml");  
        }

        // Action Calendar, trả về view từ thư mục Admin/App
        public IActionResult Lock_Screen()
        {
            return View("~/Views/Admin/Account/Lock_Screen.cshtml"); 
        }
    }
}
