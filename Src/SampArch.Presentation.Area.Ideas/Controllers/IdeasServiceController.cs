using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Ideas;
using System.Web.Mvc;
using SampArch.Presentation.Area.Ideas.Models;
using SampArch.Utilities.ActionResults.CsvResult;

namespace SampArch.Presentation.Area.Ideas
{
    public class IdeasServiceController : Controller
    {
        private IIdeaRepository _repo;

        public IdeasServiceController(IIdeaRepository repo)
        {
            _repo = repo;
        }

        public ActionResult DownloadCsv()
        {
            var vm = _repo.GetAll().Select(idea => new IdeaInList(idea));
            string fileName = string.Format(
                "{0}_Ideas.csv",
                DateTime.Now.ToString("yyyy_MM_dd"));

            var csv = new FluentCsvViewModel<IdeaInList>(vm)
                        .IncludeColumnHeaders(true)
                            .Map(x => x.Id).WithHeader("Id")
                            .Map(x => x.Title).WithHeader("Titre")
                            .Map(x => x.Author).WithHeader("Auteur")
                            .Map(x => x.CreationDate.ToString("yyyy-MM-dd")).WithHeader("Date")
                            .Map(x => x.VotesUp).WithHeader("Votes Up")
                            .ToActionResult(fileName);


            return csv;

        }
        
    }
}
