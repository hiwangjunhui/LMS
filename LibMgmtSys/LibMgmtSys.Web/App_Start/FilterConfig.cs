﻿using System.Web;
using System.Web.Mvc;

namespace LibMgmtSys.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Filters.CustomHandleErrorAttribute());
            filters.Add(new Filters.LoginRequiredAttribute());
        }
    }
}
