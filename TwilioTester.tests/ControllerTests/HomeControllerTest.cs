using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Xunit;
using TwilioTester.Controllers;
using TwilioTester.Models;


namespace TwilioTester.tests.ControllerTests
{
    public class HomeTest
    {
        [Fact]
        public void TypeIsTheSame()
        {
            HomeController controller = new HomeController();

            var result = TextMessage.GetMessages();
            Assert.IsType<IActionResult>(result);
        }

        [Fact]
        public void Get_modelList_Index_Test()
        {
            HomeController controller = new HomeController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsType<List<TwilioTester.Models.Contact>>(result);

        }
    }
}
