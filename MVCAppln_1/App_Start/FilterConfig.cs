﻿using System.Web;
using System.Web.Mvc;

namespace MVCAppln_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute()); // for authorizing for global level
        }
    }
}
