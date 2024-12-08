using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Configuration;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace CarInsuranceManage.Controllers.Customer
{
    public class LoginPhoneController : Controller
    {
        private readonly CarInsuranceDbContext _context;
        private readonly TwilioSettings _twilioSettings;

        // Inject DbContext và TwilioSettings vào controller
        public LoginPhoneController(CarInsuranceDbContext context, IOptions<TwilioSettings> twilioSettings)
        {
            _context = context;
            _twilioSettings = twilioSettings.Value;
        }

        
        [HttpPost]
        public async Task<IActionResult> LoginWithPhone(string phoneNumber)
        {
            // Kiểm tra nếu số điện thoại hợp lệ
            if (string.IsNullOrEmpty(phoneNumber))
            {
                TempData["WarningMessage"] = "Please enter a valid phone number.";
                return View("~/Views/Customer/Account/Login_Phone.cshtml");
            }

            // Tạo mã OTP (ví dụ: 6 chữ số ngẫu nhiên)
            string otp = new Random().Next(100000, 999999).ToString();

            // Gửi OTP qua SMS
            await SendOtpAsync(phoneNumber, otp);

            // Lưu OTP vào session hoặc cơ sở dữ liệu tạm thời để xác minh sau này
            HttpContext.Session.SetString("OtpCode", otp);
            HttpContext.Session.SetString("PhoneNumber", phoneNumber);

            // Chuyển hướng tới trang nhập OTP
            return RedirectToAction("Verify_Phone");
        }

        private async Task SendOtpAsync(string phoneNumber, string otp)
        {
            try
            {
                TwilioClient.Init(_twilioSettings.AccountSid, _twilioSettings.AuthToken);

                var message = MessageResource.Create(
                    body: $"Your OTP code is {otp}",
                    from: new PhoneNumber(_twilioSettings.PhoneNumber),
                    to: new PhoneNumber(phoneNumber)
                );

                Console.WriteLine($"OTP sent to {phoneNumber}: {message.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending OTP: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult VerifyOtp(string otp)
        {
            // Lấy mã OTP đã lưu trong session
            var sessionOtp = HttpContext.Session.GetString("OtpCode");
            var phoneNumber = HttpContext.Session.GetString("PhoneNumber");

            if (sessionOtp != otp)
            {
                TempData["WarningMessage"] = "Invalid OTP. Please try again.";
                return View("~/Views/Customer/Account/Verify_phone.cshtml");
            }

            // OTP hợp lệ, thực hiện đăng nhập hoặc chuyển hướng
            // Ví dụ: Lưu thông tin đăng nhập người dùng
            TempData["SuccessMessage"] = "Login successful!";
            return RedirectToAction("Index", "Home");
        }
    }
}
