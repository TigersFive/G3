using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CarInsuranceManage.Controllers.Customer
{
    public class SuportController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SendMail(string email)
        {
            // Kiểm tra nếu email hợp lệ
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                TempData["Message"] = "Please provide a valid email address.";
                return Redirect(Request.Headers["Referer"].ToString() ?? Url.Action("Index", "Home"));
            }

            try
            {
                // Cấu hình gửi email
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("insurancecarsore@gmail.com", "bfuv iniw uecz xgyl"), // This should be secured!
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("insurancecarsore@gmail.com"),
                    Subject = "Support Request - Car Insurance Management",
                    Body = $@"Hello,

                        Thank you for reaching out to Car Insurance Management. We have received your request for support and our team is on it! 

                        We're committed to providing you with the best assistance possible. Please allow us some time to review your query and get back to you with a comprehensive response.

                        In the meantime, feel free to explore our [FAQs](#) or [Customer Support Portal](#) for immediate answers to common questions.

                        Best regards,
                        The Car Insurance Management Team

                        ---

                        Customer Support: support@carinsurancemanagement.com
                        Phone: +84-384-804-325
                        Website: www.carinsurancemanagement.com
                        ",
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(email);

                // Gửi email
                await smtpClient.SendMailAsync(mailMessage);

                TempData["Message"] = "An email has been send to you";
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Error: {ex.Message}";
            }

            // Quay lại trang trước đó hoặc trang mặc định
            return Redirect(Request.Headers["Referer"].ToString() ?? Url.Action("Index", "Home"));
        }

        // Kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            // Regex kiểm tra email hợp lệ
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}
