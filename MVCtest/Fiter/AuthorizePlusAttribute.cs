using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCtest.Fiter
{
    public class AuthorizePlusAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]) == true)
            {
                filterContext.Controller.ViewBag.Name = filterContext.HttpContext.Session["Name"].ToString();
                filterContext.Controller.ViewBag.Email = filterContext.HttpContext.Session["Email"].ToString();
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.Name = "SIGN IG";
            filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "MemberCenter", action = "index" }));
        }
    }
}