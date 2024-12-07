using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceManage.Controllers.Admin
{
    public class ComponentsController : Controller
    {
        public IActionResult Nestedable()
        {
            return View("~/Views/Admin/Components/Nestedable.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Noui_Slider()
        {
            return View("~/Views/Admin/Components/Noui_Slider.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Sweet_Alert()
        {
            return View("~/Views/Admin/Components/Sweet_Alert.cshtml");  // Đường dẫn tuyệt đối
        }

        public IActionResult Toastr()
        {
            return View("~/Views/Admin/Components/Toastr.cshtml");  // Đường dẫn tuyệt đối
        }
    }
}
