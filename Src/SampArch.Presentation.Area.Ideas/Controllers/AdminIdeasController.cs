using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampArch.Domain.Ideas;

namespace SampArch.Presentation.Area.Ideas.Controllers
{
    public class AdminIdeasController : Controller
    {
        private IIdeaRepository _repo;

        public AdminIdeasController(IIdeaRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
