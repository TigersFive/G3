using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class PaymentController : Controller
{
    private readonly MomoPaymentService _momoPaymentService;

    public PaymentController(MomoPaymentService momoPaymentService)
    {
        _momoPaymentService = momoPaymentService;
    }

    // GET: /Customer/Payment/Index
    public IActionResult Index()
    {
        return View("~/Views/Customer/Payment/Index.cshtml");
    }

    // POST: /Customer/Payment/Process
    [HttpPost]
    public async Task<IActionResult> Process(decimal amount, string orderId)
    {
        var paymentResponse = await _momoPaymentService.CreatePaymentRequestAsync(amount, orderId);

        // Parse paymentResponse (you may need to handle it depending on Momo's response format)
        return Redirect(paymentResponse);  // Redirect user to Momo payment page
    }

    // GET: /Customer/Home/PaymentCallBack
    public IActionResult PaymentCallBack()
    {
        // Xử lý kết quả trả về từ Momo (nếu thanh toán thành công)
        return View();
    }

    // GET: /Customer/Home/MomoNotify
    public IActionResult MomoNotify()
    {
        // Xử lý thông báo của Momo
        return View();
    }
}
