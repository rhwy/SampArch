using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SampArch.Presentation.Core.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Start()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
