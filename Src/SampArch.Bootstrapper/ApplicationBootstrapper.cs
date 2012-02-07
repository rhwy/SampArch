using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Mediator;
using SampArch.Domain.Common;

namespace SampArch.Bootstrapper
{
    public class ApplicationBootstrapper : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Account", // Route name
                "Account/{action}", // URL with parameters
                new { controller = "Account", action = "LogOn" } // Parameter defaults
            );

            //notre route par défaut doit être limitative, éviter les url catch all /controller/action
            routes.MapRoute(
                "Contact", // Route name
                "Contact/{action}", // URL with parameters
                new { controller = "Contact", action = "SendMessage" } // Parameter defaults
            );


            //notre route par défaut doit être limitative, éviter les url catch all /controller/action
            routes.MapRoute(
                "Default", // Route name
                "Home/{action}", // URL with parameters
                new { controller = "Home", action = "Start" } // Parameter defaults
            );

            routes.MapRoute(
                "Root", // Route name
                "", // URL with parameters
                new { controller = "Home", action = "Start" } // Parameter defaults
            );
        }

        public void Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            
        }

        protected void Application_Start()
        {
            Start();
        }
    }
}
