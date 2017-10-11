using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationSessionMVC.Models;
using AuthenticationSessionMVC.ViewModel;

namespace AuthenticationSessionMVC.Security
{
    public class CustomAutherizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersistor.UserName))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "AccountTest", Action = "Index" }));
            }
            else
            {
                AccountModel am = new AccountModel();
                CustomPrincipal cp = new CustomPrincipal(am.Find(SessionPersistor.UserName));
                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Error", action = "Index" }));
                }
               
            }
        }
    }
}