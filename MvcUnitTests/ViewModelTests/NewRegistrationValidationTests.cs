using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Starter.Models.NewsletterRegistration;

namespace MvcUnitTests.ViewModelTests
{
    [TestClass]
    public class NewRegistrationValidationTests
    {
        private Helpers.AttributeHelper<NewRegistration> _registration;

        [TestInitialize]
        public void SetUp()
        {
            _registration = new Helpers.AttributeHelper<NewRegistration>();
        }

        [TestMethod]
        public void FirstNameIsRequired()
        {
            Assert.IsTrue(_registration.PropertyHasAttribute(typeof(RequiredAttribute), "FirstName"));
        }

        [TestMethod]
        public void LastNameIsRequired()
        {
            Assert.IsTrue(_registration.PropertyHasAttribute(typeof(RequiredAttribute), "LastName"));
        }

        [TestMethod]
        public void FirstNameHasProperErrorMessage()
        {
            var attrib =
                _registration.GetAttributeOnProperty(typeof (RequiredAttribute), "FirstName") as RequiredAttribute;
            Assert.AreEqual("First Name Must Be Provided", attrib.ErrorMessage);
        }
    }
}