using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SampArch.Presentation.Area.Ideas
{
    public class IdeaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Ideas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminIdeasRoute",
                "Ideas/Admin/{action}/{id}",
                new { controller = "AdminIdeas", action = "Index", id = UrlParameter.Optional },
                new[] { "SampArch.Presentation.Area.Ideas.Controllers" }

            );

            context.MapRoute(
                "IdeasRoute",
                "Ideas/{action}/{id}",
                new { controller = "SiteIdeas", action = "Index", id = UrlParameter.Optional },
                new[] { "SampArch.Presentation.Area.Ideas.Controllers" }

            );

            context.MapRoute(
                "IdeasServiceRoute",
                "IdeasService/{action}/{id}",
                new { controller = "IdeasService", action = "DownloadCsv", id = UrlParameter.Optional },
                new[] { "SampArch.Presentation.Area.Ideas.Controllers" }

            );

        }
    }
}
