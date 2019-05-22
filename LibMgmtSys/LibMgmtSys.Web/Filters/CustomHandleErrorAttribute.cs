using System.Web.Mvc;
using System.Web.Routing;

namespace LibMgmtSys.Web.Filters
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Home", action = "Error" }));
        }
    }
}