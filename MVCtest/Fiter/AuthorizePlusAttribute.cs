﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Fiter
{
    public class AuthorizePlusAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]) == true)
            {
                filterContext.Controller.ViewBag.Name = filterContext.HttpContext.Session["Name"].ToString();
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.Name = "SIGN IG";
        }
    }
}