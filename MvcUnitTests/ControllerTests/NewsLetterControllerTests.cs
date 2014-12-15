using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Starter.Controllers;

namespace MvcUnitTests.ControllerTests
{
    [TestClass]
    public class NewsLetterControllerTests
    {
        [TestMethod]
        public void NewReturnsAView()
        {
            var controller = new NewsLetterRegistrationController();

            var view = controller.New() as ViewResult;

            Assert.IsNotNull(view);

        }
    }
}
