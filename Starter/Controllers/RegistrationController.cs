using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Starter.Controllers
{
    public class NewsLetterRegistrationController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}
