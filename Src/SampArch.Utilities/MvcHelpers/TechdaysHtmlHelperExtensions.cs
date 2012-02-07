using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace TipsTricks.Utilities.MvcHelpers
{
    public static class TechdaysHtmlHelperExtensions
    {
        public static MvcHtmlString ImageLink(this TechdaysHtmlHelper techdays, string title, string link, string image)
        {
            UrlHelper urlHelper = new UrlHelper(techdays.HtmlHelper.ViewContext.RequestContext);
            string html = "<a href=\"{0}\" title=\"{1}\" target=\"_blank\"><img src=\"{2}\" title=\"{1}\" /></a>";
            string formatedHtml = string.Format(html, link, title, urlHelper.Image(image));
            return new MvcHtmlString(formatedHtml);
        }

        public static MvcHtmlString Nl2Br(this TechdaysHtmlHelper techdays, string input)
        {
            string html = input.Replace("\r\n", "<br />").Replace("\n", "<br />");
            return new MvcHtmlString(html);
        }

        public static MvcHtmlString DatePicker(this TechdaysHtmlHelper techdays, string name)
        {
            return techdays.DatePicker(name, null);
        }

        public static MvcHtmlString DatePicker(this TechdaysHtmlHelper techdays, string name, object value)
        {
            MvcHtmlString textBoxHtml = value == null ? techdays.HtmlHelper.TextBox(name) : techdays.HtmlHelper.TextBox(name, value);
            string jqueryScript = string.Format("<script language=\"javascript\">$(document).ready(function() {{ $('#{0}').datepicker(); }})</script>", name);

            return new MvcHtmlString(string.Concat(textBoxHtml.ToString(), jqueryScript));
        }

        public static MvcHtmlString ToMarkdown(this TechdaysHtmlHelper techdays, string content)
        {
            var md = new MarkdownDeep.Markdown();
            md.ExtraMode = true; 
            md.SafeMode = false;

            string output = md.Transform(content);
            return new MvcHtmlString(output);
        }
    }
}
