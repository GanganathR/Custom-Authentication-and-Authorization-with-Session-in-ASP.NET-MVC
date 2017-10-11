using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationSessionMVC.ViewModel;
using AuthenticationSessionMVC.Models;
using AuthenticationSessionMVC.Security;
namespace AuthenticationSessionMVC.Controllers
{
    public class AccountTestController : Controller
    {
        // GET: AccountTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(AccountViewModel avm)
        {
            try
            {
                AccountModel am = new AccountModel();
                if (string.IsNullOrEmpty(avm.AccountTest.UserName) || string.IsNullOrEmpty(avm.AccountTest.Password) || am.Login(avm.AccountTest.UserName, avm.AccountTest.Password) == null)
                {
                    ViewBag.Error = "Access denied";
                    return View("Index");
                }
                SessionPersistor.UserName = avm.AccountTest.UserName;
                return View("Success");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Logout(AccountViewModel avm)
        {
            SessionPersistor.UserName = string.Empty;
            return Redirect("Index");
        }
    }
}