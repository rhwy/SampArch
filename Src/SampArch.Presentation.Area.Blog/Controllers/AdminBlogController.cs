using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampArch.Domain.Blog;

namespace SampArch.Presentation.Area.Blog.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminBlogController : Controller
    {
        private IPostRepository _repo;

        public AdminBlogController(IPostRepository repository)
        {
            _repo = repository;
        }

        public ActionResult Index()
        {
            var posts = _repo.GetAll();
            return View(posts);
        }

    }
}
