using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Starter.Models.NewsletterRegistration;

namespace Starter.Controllers
{
    public class NewsLetterRegistrationController : Controller
    {
        [HttpGet]
        public ActionResult New()
        {
            return View(new NewRegistration());
        }

        public ActionResult Create(NewRegistration registration)
        {
            if (!ModelState.IsValid)
            {
                return View("New", registration);
            }
            else
            {
                return RedirectToAction("Thanks", registration);
            }
        }
    }
}
