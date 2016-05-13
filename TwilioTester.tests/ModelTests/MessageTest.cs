using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using TwilioTester.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace TwilioTester.tests
{
    public class MessageTest
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }

        [Fact]
        public void MessageExistTest()
        {
            var testMessage = new TextMessage();
            
            testMessage.Body = "yo";

            var result = testMessage.Body;

            Assert.Equal("yo", result);
        }
    }
}

