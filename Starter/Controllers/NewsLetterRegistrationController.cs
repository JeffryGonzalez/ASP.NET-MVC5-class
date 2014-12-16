using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Starter.Code.Interfaces;
using Starter.Models.NewsletterRegistration;

namespace Starter.Controllers
{
	public class NewsLetterRegistrationController : Controller
	{
		private ICreateNewsletterRegistrations _newsletterRegistrar;

		[HttpGet]
		public ActionResult New()
		{
			return View(new NewRegistration());
		}

		public NewsLetterRegistrationController(ICreateNewsletterRegistrations newsletterRegistrar)
		{
			_newsletterRegistrar = newsletterRegistrar;
		}

		[HttpPost]
		public ActionResult Create(NewRegistration registration)
		{
			if (!ModelState.IsValid)
			{
				return View("New", registration);
			}
			else
			{
				_newsletterRegistrar.Create(registration);
				TempData["confirmation"] = registration;
				return RedirectToAction("Thanks");
			}
		}

		[HttpGet]
		public ActionResult Thanks()
		{
			if (TempData.ContainsKey("confirmation"))
				return View(TempData["confirmation"]);
			return RedirectToAction("New");
		}
	}
}
