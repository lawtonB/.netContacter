using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TwilioTester.Models;
using System.Configuration;
using Twilio.TwiML.Mvc;
using Twilio;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TwilioTester.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            var allContacts = db.Contacts.ToList();
            return View(allContacts);
        }

        public IActionResult GetMessages()
        {
            var allMessages = TextMessage.GetMessages();
            return View(allMessages);
        }

        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(TextMessage newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index");
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public IActionResult Articles()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VoiceCall()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VoiceCall(PhoneCall phoneCall)
        {
            
            var client = new TwilioRestClient(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            if (client.InitiateOutboundCall(
                "+19713402408", phoneCall.To, "http://demo.twilio.com/welcome/voice/"
                ).RestException == null)
            {
                Console.WriteLine(string.Format("Started call: {0}", client.InitiateOutboundCall(
                "+19713402408", phoneCall.To, "http://demo.twilio.com/welcome/voice/"
                ).Sid));
            }
            else
            {
                Console.WriteLine(string.Format("Error: {0}", client.InitiateOutboundCall(
                "+19713402408", phoneCall.To, "http://demo.twilio.com/welcome/voice/"
                ).RestException.Message));
            }
            Console.WriteLine("Calling~!");
            return View();
        }

        [HttpGet]
        public IActionResult CallLog()
        {
            var client = new TwilioRestClient(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);

            var calls = client.ListCalls();
            Console.WriteLine(calls.Calls.Count
                );
            if (calls.RestException != null)
            {
                Console.WriteLine((string.Format("Error: {0}", calls.RestException.Message)));
            }
            return View(calls.Calls);
        }


       

    }
}
