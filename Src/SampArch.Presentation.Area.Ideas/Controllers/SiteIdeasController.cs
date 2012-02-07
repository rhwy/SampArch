using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampArch.Domain.Ideas;
using SampArch.Presentation.Area.Ideas.Models;
using SampArch.Utilities.ActionResults.CsvResult;
using SampArch.Domain.Common;

namespace SampArch.Presentation.Area.Ideas.Controllers
{
    public class SiteIdeasController  : Controller
    {
        private IIdeaRepository _repo;

        public SiteIdeasController(IIdeaRepository repo)
        {
            _repo = repo;
        }

        public ViewResult Index()
        {
            var vm = _repo.GetAll().Select(idea => new IdeaInList(idea));
            return View("Index", vm);
        }

        public ViewResult SortByDateDesc()
        {
            var vm = _repo.SortByDesc(x=> x.CreationDate).Select(idea => new IdeaInList(idea));
            return View("Index", vm);
        }

        public ViewResult SortByDate()
        {
            var vm = _repo.SortBy(x => x.CreationDate).Select(idea => new IdeaInList(idea));
            return View("Index", vm);
        }

        public ViewResult SortByVotesDown()
        {
            var vm = _repo.SortBy(x => x.Votes.Down).Select(idea => new IdeaInList(idea));
            return View("Index", vm);
        }

        public ViewResult SortByVotesUp()
        {
            var vm = _repo.SortBy(x => x.Votes.Up).Select(idea => new IdeaInList(idea));
            return View("Index", vm);
        }

        public ViewResult SortByTitle()
        {
            var vm = _repo.SortBy(x => x.Title).Select(idea => new IdeaInList(idea));
            return View("Index", vm);
        }
        public ViewResult SortByComments()
        {
            var vm = _repo.SortBy(x => x.Comments.Count).Select(idea => new IdeaInList(idea));
            return View("Index", vm);
        }
        public ViewResult Details(int id)
        {
            Idea idea = _repo.GetById(id);
            
            return View(idea);
        }

        //
        // GET: /Suggests/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Suggests/Create

        [HttpPost]
        public ActionResult Create(Idea idea)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(idea);
                return RedirectToAction("Index");
            }

            return View(idea);
        }

        //
        // GET: /Suggests/Edit/5

        public ActionResult Edit(int id)
        {
            Idea suggest = _repo.GetById(id);
            return View(suggest);
        }

        //
        // POST: /Suggests/Edit/5

        [HttpPost]
        public ActionResult Edit(Idea suggest)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(suggest);
                return RedirectToAction("Index");
            }
            return View(suggest);
        }

        //
        // GET: /Suggests/Delete/5

        public ActionResult Delete(int id)
        {
            Idea suggest = _repo.GetById(id);
            return View(suggest);
        }

        //
        // POST: /Suggests/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddComment(AddCommentIdea comment)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ModelState.AddModelError("Author", "You need to be logged");

            }
            var idea = _repo.GetById(comment.IdeaId);
            if(idea != null)
            {
                idea.AddComment(new Comment { Content = comment.Content, PublishDate = DateTime.Now, UserName = User.Identity.Name });
            }
            return RedirectToAction("Index");
        }


    }
}
