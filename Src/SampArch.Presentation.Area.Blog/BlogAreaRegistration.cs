using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SampArch.Presentation.Blog.Ideas
{
    public class BlogAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Blog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminBlogRoute",
                "Blog/Admin/{action}/{id}",
                new { controller = "AdminBlog", action = "Index", id = UrlParameter.Optional },
                new[] { "SampArch.Presentation.Area.Blog.Controllers" }

            ); 
            
            context.MapRoute(
                "BlogRoute",
                "Blog/{action}/{id}",
                new { controller = "Blog", action = "Index", id = UrlParameter.Optional },
                new[] { "SampArch.Presentation.Area.Blog.Controllers" }

            );

            
        }
    }
}
