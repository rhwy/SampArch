using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace SampArch.Utilities
{
    public static class WebViewPageExtensions
    {
        public static void SetCookie(this WebViewPage page, string name, string value = "")
        {
            HttpCookie cookie = page.Context.Response.Cookies.Get(name);
            if (cookie == null)
            {
                cookie = new HttpCookie(name, value);
                page.Context.Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = value;
                page.Context.Response.Cookies.Set(cookie);
            }
        }

        public static string GetCookie(this WebViewPage page, string name)
        {
            HttpCookie cookie = page.Context.Response.Cookies.Get(name);
            if (cookie == null)
            {
                return cookie.Value;
            }
            return string.Empty;
        }
    }
}
