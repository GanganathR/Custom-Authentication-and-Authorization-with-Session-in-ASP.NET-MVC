using AuthenticationSessionMVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationSessionMVC.Controllers
{
    public class FrontController : Controller
    {
        // GET: Front
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAutherize(Roles ="superadmin")]
        public ActionResult Work1()
        {
            return View("Work1");  
        }
        [CustomAutherize(Roles = "superadmin,admin")]
        public ActionResult Work2()
        {
            return View("Work2");
        }

        [CustomAutherize(Roles = "superadmin,admin,employee")]
        public ActionResult Work3()
        {
            return View("Work3");
        } 

    }
}