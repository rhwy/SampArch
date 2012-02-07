using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TipsTricks.Utilities.MvcHelpers
{
    public static class HtmlHelperExtensions
    {
        public static TechdaysHtmlHelper Techdays(this HtmlHelper htmlHelper)
        {
            return new TechdaysHtmlHelper(htmlHelper);
        }
    }
}
