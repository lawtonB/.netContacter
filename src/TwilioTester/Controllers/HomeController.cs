using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TwilioTester.Models;
using System.Configuration;
using Twilio.TwiML.Mvc;
using Twilio;
using RestSharp;
using RestSharp.Authenticators;

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
            string email = contact.email;
            string firstName = contact.firstName;
            string lastName = contact.lastName;
            string number = contact.number;

            string subscribed = Request.Form["subscribed"];

            if (subscribed == "subscribed")
            {
                var client = new RestClient("https://us13.api.mailchimp.com/3.0/")
                {
                    Authenticator = new HttpBasicAuthenticator("LawtonBrowning", EnvironmentVariables.MailChimpApi)

                };

                RestRequest request = new RestRequest("lists/87d736635b/members/", Method.POST);

                var newMailChimp = new
                {
                    email_address = email,
                    status = subscribed,
                    merge_fields = new
                    {
                        FNAME = firstName,
                        LNAME = lastName
                    }
                };
                var json = request.JsonSerializer.Serialize(newMailChimp);
                Console.WriteLine(json);
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }

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
