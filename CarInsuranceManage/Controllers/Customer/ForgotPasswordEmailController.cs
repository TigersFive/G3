// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Authentication.Google;
// using Microsoft.AspNetCore.Mvc;
// using CarInsuranceManage.Models;
// using CarInsuranceManage.Database;
// using System.Security.Claims;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.Facebook;

// namespace CarInsuranceManage.Controllers.Customer
// {
//     public class ForgotPasswordEmailController : Controller
//     {
//         private readonly CarInsuranceDbContext _context;

//         public ForgotPasswordEmailController(CarInsuranceDbContext context)
//         {
//             _context = context;
//         }

//         // Process the email submission
//         [HttpPost("")]
//         public async Task<IActionResult> Index(ForgotPasswordViewModel model)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return View(model);
//             }

//             // Check if the email exists
//             var user = _context.Customers.FirstOrDefault(c => c.Email == model.Email);
//             if (user == null)
//             {
//                 ModelState.AddModelError("", "Email không tồn tại.");
//                 return View(model);
//             }

//             // Generate a new reset token (8 characters)
//             string resetToken = GenerateResetToken();

//             // Store the reset token and set the expiry time (e.g., 1 hour)
//             user.ResetToken = resetToken; // Store plain reset token
//             user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1); // Set expiry time to 1 hour from now

//             await _context.SaveChangesAsync(); // Save changes to the database before sending the email

//             // Send the reset token via email after storing it
//             SendResetTokenEmail(model.Email, resetToken);

//             ViewBag.Message = "Mã đặt lại mật khẩu đã được gửi đến email của bạn.";
//             return View();
//         }

//         // Generate a random alphanumeric reset token
//         private string GenerateResetToken()
//         {
//             var random = new Random();
//             const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
//             return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
//         }

//         // Send the reset token via email
//         // Send the reset token via email
//         private void SendResetTokenEmail(string email, string resetToken)
//         {
//             var message = new MimeMessage();
//             message.From.Add(new MailboxAddress("Restaurantly", "bahatmittt@gmail.com"));
//             message.To.Add(new MailboxAddress("", email));
//             message.Subject = "Mã đặt lại mật khẩu của bạn";

//             // Generate the reset password URL
// var resetPasswordUrl = Url.Action("Index", "reset-password", new { token = resetToken, email }, Request.Scheme);

//             // Include the reset token and the reset link in the email body
//             message.Body = new TextPart("plain")
//             {
//                 Text = $@"
//                 Xin chào,

//                 Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn tại Restaurantly. 
//                 Dưới đây là mã token của bạn để đặt lại mật khẩu:

//                 Mã token: {resetToken}

//                 Bạn có thể đặt lại mật khẩu bằng cách truy cập vào liên kết sau:
//                 {resetPasswordUrl}

//                 Vui lòng lưu ý:
//                 - Mã token này có hiệu lực trong vòng 1 giờ kể từ khi yêu cầu được gửi.
//                 - Nếu bạn không sử dụng mã token trong khoảng thời gian này, bạn sẽ cần yêu cầu lại một mã mới.
//                 - Để bảo mật tài khoản của bạn, hãy không chia sẻ mã token này với bất kỳ ai.

//                 Nếu bạn không yêu cầu đặt lại mật khẩu, vui lòng bỏ qua email này.

//                 Trân trọng,
//                 Nhóm hỗ trợ của Restaurantly"
//             };

//             using (var client = new SmtpClient())
//             {
//                 try
//                 {
//                     client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
//                     client.Authenticate("bahatmittt@gmail.com", "wfod orhz zyzy sokd"); // Use App Password if 2FA is enabled
//                     client.Send(message);
//                     client.Disconnect(true);
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine($"Gửi email thất bại: {ex.Message}");
//                 }
//             }
//         }

//     }
// }