using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TipsTricks.Utilities.MvcHelpers
{
    public class TechdaysHtmlHelper
    {
        private readonly HtmlHelper _htmlHelper;

        internal HtmlHelper HtmlHelper
        {
            get { return _htmlHelper; }
        } 

        public TechdaysHtmlHelper(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }
    }
}
