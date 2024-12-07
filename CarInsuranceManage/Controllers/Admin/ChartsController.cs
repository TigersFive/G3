using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class ChartsController : Controller
    {
        public IActionResult Flot()
        {
            return View("~/Views/Admin/Charts/Flot.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Morris()
        {
            return View("~/Views/Admin/Charts/Morris.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Chartjs()
        {
            return View("~/Views/Admin/Charts/Chartjs.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Chartist()
        {
            return View("~/Views/Admin/Charts/Chartist.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Sparkline()
        {
            return View("~/Views/Admin/Charts/Sparkline.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Peity()
        {
            return View("~/Views/Admin/Charts/Peity.cshtml");  // Đường dẫn tuyệt đối
        }
    }
}
