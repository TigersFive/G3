using Microsoft.AspNetCore.Mvc;
using CarInsuranceManage.Models;
using CarInsuranceManage.Database;
using System;
using System.Security.Claims;

namespace CarInsuranceManage.Controllers
{
    public class ContactController : Controller
    {
        private readonly CarInsuranceDbContext _context;

        public ContactController(CarInsuranceDbContext context)
        {
            _context = context;
        }

        // GET: /Contact/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Customer/Contact/Index.cshtml");
        }

        // POST: /Contact/Send
        [HttpPost]
        public IActionResult Send(Contact contact)
        {
            // Check if the user is authenticated
            if (!User.Identity.IsAuthenticated)
            {
                // Store a message in TempData before redirecting
                TempData["ErrorMessage"] = "You must be logged in to submit a contact form.";
                return RedirectToAction("Login", "Account"); // Redirect to login page
            }

            // Get the customer_id from session (instead of using claims)
            var customerId = HttpContext.Session.GetInt32("customer_id");

            // Validate the form data
            if (ModelState.IsValid)
            {
                // Check if customerId is null
                if (customerId == null)
                {
                    TempData["ErrorMessage"] = "Customer information is missing.";
                    return RedirectToAction("Login", "Account");
                }

                // Set the customer_id to the current logged-in user's ID
                contact.customer_id = customerId.Value;

                // Set the status and dates
                contact.status = true;
                contact.date_added = DateTime.Now;
                contact.date_modified = DateTime.Now;

                // Save to the database
                _context.Contacts.Add(contact);
                _context.SaveChanges();

                // Store a success message in TempData
                TempData["SuccessMessage"] = "Your message has been successfully sent!";

                // Redirect to a different action or stay on the current page
                return RedirectToAction("Index", "Contact"); // Or stay on the same page to show the success message
            }

            // If the model is not valid, stay on the contact page and show validation errors
            TempData["ErrorMessage"] = "There was an issue with your form submission. Please check the inputs.";
            return View("~/Views/Customer/Contact/Index.cshtml", contact);
        }

    }
}
