using CarInsuranceManage.Database;
using CarInsuranceManage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarInsuranceManage.Controllers
{
    public class ContactsController : Controller
    {
        private readonly CarInsuranceDbContext _dbContext;

        public ContactsController(CarInsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

     
       
        [HttpPost]
        public IActionResult DeleteContacts(int id)
        {
            var contact = _dbContext.Contacts.Find(id); // Corrected to Contacts
            if (contact == null)
            {
                return NotFound();
            }
            _dbContext.Contacts.Remove(contact); // Corrected to remove the contact
            _dbContext.SaveChanges();
            return Json(new { success = true }); // Return success in JSON format
        }

    }


}