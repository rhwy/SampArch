using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TipsTricks.Utilities.MvcHelpers
{
    public static class UrlHelperExtensions
    {
        public static string Image(this UrlHelper urlHelper, string filename)
        {
            string absoluteUrl = string.Format("~/Content/Images/{0}", filename);
            return urlHelper.Content(absoluteUrl);
        }

        public static string Stylesheet(this UrlHelper urlHelper, string stylesheet)
        {
            string absoluteUrl = string.Format("~/Content/Styles/{0}", stylesheet);
            return urlHelper.Content(absoluteUrl);
        }

        public static string JQueryStylesheet(this UrlHelper urlHelper, string stylesheet)
        {
            string absoluteUrl = string.Format("~/Content/themes/base/{0}", stylesheet);
            return urlHelper.Content(absoluteUrl);
        }

        public static string Script(this UrlHelper urlHelper, string script)
        {
            string absoluteUrl = string.Format("~/Scripts/{0}", script);
            return urlHelper.Content(absoluteUrl);
        }
    }
}
