using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysVentas.Code
{
    public static class HtmlMvcHelper
    {
        public static string IsActive(this HtmlHelper html, int value)
        {
            object menuId = 0;
            html.ViewData.TryGetValue("menuActive", out menuId);
            if (menuId == null) return "";
            var result = value == (int)menuId ? "active" : "";
            return result;
        }
    }
}