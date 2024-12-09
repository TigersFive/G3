using   MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Collections.Generic;

public class EmailController : Controller
{
    private const string EmailAddress = "insurancecarsore@gmail.com";
    private const string Password = "bfuv iniw uecz xgyl"; // Be sure to secure the password properly

    public IActionResult Inbox()
    {
        var emailList = GetEmails(); // Get the email list from Gmail
        ViewData["EmailCount"] = emailList.Count; // Pass email count to View
        return View("~/Views/Admin/Email/Inbox.cshtml", emailList); // Pass the email list to the View
    }

    private List<MimeMessage> GetEmails()
    {
        var messages = new List<MimeMessage>();

        using (var client = new ImapClient())
        {
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(EmailAddress, Password);

            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            for (int i = 0; i < inbox.Count; i++)
            {
                var message = inbox.GetMessage(i);
                messages.Add(message); // Add email to the list
            }

            client.Disconnect(true);
        }

        return messages;
    }

    // Display email details
    public IActionResult Read(int id)
    {
        var message = GetEmailById(id); // Get email by ID
        return View("~/Views/Admin/Email/Read.cshtml", message); // Pass email to Read View
    }

    // Get email by ID
    private MimeMessage GetEmailById(int id)
    {
        MimeMessage message = null;

        using (var client = new ImapClient())
        {
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(EmailAddress, Password);

            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            // Get email from Inbox by ID
            message = inbox.GetMessage(id);

            client.Disconnect(true);
        }

        return message;
    }

    // Get emails from Trash
    private List<MimeMessage> GetTrashEmails()
    {
        var messages = new List<MimeMessage>();

        using (var client = new ImapClient())
        {
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(EmailAddress, Password);

            var trash = client.GetFolder(SpecialFolder.Trash);
            trash.Open(FolderAccess.ReadOnly);

            for (int i = 0; i < trash.Count; i++)
            {
                var message = trash.GetMessage(i);
                messages.Add(message); // Add email to the list
            }

            client.Disconnect(true);
        }

        return messages;
    }

    public IActionResult Trash()
    {
        var trashList = GetTrashEmails(); // Get the email list from Gmail
        ViewData["EmailCount"] = trashList.Count; // Pass email count to View
        return View("~/Views/Admin/Email/Trash.cshtml", trashList); // Pass the email list to the View
    }

    // Permanently delete emails
    [HttpPost]
    public IActionResult DeleteEmails(string[] emailIds)
    {
        using (var client = new ImapClient())
        {
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(EmailAddress, Password);

            var trash = client.GetFolder(SpecialFolder.Trash);
            trash.Open(FolderAccess.ReadWrite);

            foreach (var id in emailIds)
            {
                var message = trash.Search(SearchQuery.HeaderContains("Message-Id", id));
                foreach (var uniqueId in message)
                {
                    trash.AddFlags(uniqueId, MessageFlags.Deleted, true);
                }
            }

            trash.Expunge(); // Permanently remove the messages
            client.Disconnect(true);
        }

        return RedirectToAction("Trash");
    }

    // Display email details from Trash
    public IActionResult ViewTrash(int id)
    {
        var message = GetTrashEmailById(id); // Get email by ID from Trash
        return View("~/Views/Admin/Email/ViewTrash.cshtml", message); // Pass email to ViewTrash View
    }

    // Get email by ID from Trash
    private MimeMessage GetTrashEmailById(int id)
    {
        MimeMessage message = null;

        using (var client = new ImapClient())
        {
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(EmailAddress, Password);

            var trash = client.GetFolder(SpecialFolder.Trash);
            trash.Open(FolderAccess.ReadOnly);

            // Get email from Trash by ID
            message = trash.GetMessage(id);

            client.Disconnect(true);
        }

        return message;
    }
}
