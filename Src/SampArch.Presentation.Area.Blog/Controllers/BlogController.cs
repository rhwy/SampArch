using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampArch.Domain.Blog;

namespace SampArch.Presentation.Area.Blog.Controllers
{
    public partial class BlogController : Controller
    {
        private IPostRepository _repo;

        public BlogController(IPostRepository repository)
        {
            _repo = repository;
        }

        public virtual ActionResult Index()
        {
            var posts = _repo.GetAll();
            return View(posts);
        }


        public virtual ActionResult Details(int id)
        {
            var post = _repo.GetById(id);
            return View(post);
        }
    }
}
