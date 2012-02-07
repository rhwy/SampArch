using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SampArch.Utilities
{
    public class ViewModelBaseActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewModelBase viewModelBase = filterContext.Controller.ViewData.Model as ViewModelBase;
            if(viewModelBase != null)
            {
                viewModelBase.IsAuthenticated = filterContext.HttpContext.User.Identity.IsAuthenticated;
                if (viewModelBase.IsAuthenticated)
                {
                    viewModelBase.Username = filterContext.HttpContext.User.Identity.Name;
                }
                else
                {
                    viewModelBase.Username = "Utilisateur anonyme";
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
