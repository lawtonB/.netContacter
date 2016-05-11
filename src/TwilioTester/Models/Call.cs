using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;

namespace TwilioTester.Models
{
    public class Call
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Url { get; set; }

        public void VoiceCall()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Messages.json", Method.POST);
           // var twilio = new TwilioRestClient(EnvironmentVariables.AccountSid,
           //EnvironmentVariables.AuthToken);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Url", Url);
            //var options = new CallOptions();
            //options.Url = "http://demo.twilio.com/docs/voice.xml";
            //options.To = "+15034593784";
            //options.From = "+19713402408";
            //var call = twilio.InitiateOutboundCall(options);
            client.Execute(request);

            //Console.WriteLine(call.Sid);
        }
    }
}
