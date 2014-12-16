using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Starter.Code.Interfaces;
using Starter.Controllers;
using Starter.Models.NewsletterRegistration;

namespace MvcUnitTests.ControllerTests
{
	[TestClass]
	public class NewsLetterControllerTests
	{
		private NewsLetterRegistrationController _controller;
		private ICreateNewsletterRegistrations _registrar;

		[TestInitialize]
		public void Setup()
		{
			_registrar = MockRepository.GenerateMock<ICreateNewsletterRegistrations>();
			_controller = new NewsLetterRegistrationController(_registrar);
		}
		[TestMethod]
		public void NewReturnsAView()
		{

			var view = _controller.New() as ViewResult;

			Assert.IsNotNull(view);

		}

		[TestMethod]
		public void ReturnsTheModel()
		{
			var view = _controller.New() as ViewResult;

			var model = view.Model as NewRegistration;

			Assert.IsNotNull(model);
		}

		[TestMethod]
		public void IsMarkedAsGet()
		{
			Assert.IsTrue(Helpers.MethodHasAttribute<HttpGetAttribute>(() => _controller.New()));
		}

		[TestMethod]
		public void CreateTakes()
		{
			var registration = new NewRegistration();

			var result = _controller.Create(registration) as ViewResult;
		}

		[TestMethod]
		public void ReturnsBackToNewIfModelStateErrors()
		{
			var registration = new NewRegistration();

			_controller.ModelState.AddModelError("x", "some error");

			var result = _controller.Create(registration) as ViewResult;

			Assert.AreEqual("New", result.ViewName);

		}

		[TestMethod]
		public void ReturnsThanksViewIfNoModelStateErrors()
		{
			var registration = new NewRegistration() { FirstName = "George" };

			var result = _controller.Create(registration) as RedirectToRouteResult;
			Assert.IsFalse(result.Permanent);
			Assert.AreEqual("Thanks", result.RouteValues["action"]);
		}

		[TestMethod]
		public void CreateAddsIt()
		{
			var registration = new NewRegistration();

			var result = _controller.Create(registration);

			_registrar.AssertWasCalled(r=>r.Create(registration));
		}

		[TestMethod]
		public void AddsRegistrationToTempData()
		{
			var registration = new NewRegistration();

			var result = _controller.Create(registration) as RedirectToRouteResult;

			Assert.IsTrue(_controller.TempData.ContainsKey("confirmation"));
		}

	}



}
