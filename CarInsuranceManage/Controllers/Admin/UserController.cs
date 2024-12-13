using CarInsuranceManage.Database;
using CarInsuranceManage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarInsuranceManage.Controllers
{
    public class UserController : Controller
    {
        private readonly CarInsuranceDbContext _dbContext;

        public UserController(CarInsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View("~/Views/Admin/User/CreateUser.cshtml");
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/User/CreateUser.cshtml", user);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/User/EditUser.cshtml", user);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/User/EditUser.cshtml", user);
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return Json(new { success = true }); // Trả về JSON thông báo xóa thành công
        }


        [HttpGet]
        public IActionResult Index()
        {
            var users = _dbContext.Users.ToList();
            return View("~/Views/Admin/User/Index.cshtml", users);
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/User/ConfirmDelete.cshtml", user);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int user_id)
        {
            var user = _dbContext.Users.Find(user_id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FeedBack()
        {
            var usersFeedBack = _dbContext.Contacts.ToList();
            return View("~/Views/Admin/User/FeedBack.cshtml", usersFeedBack);
        }


    }


}