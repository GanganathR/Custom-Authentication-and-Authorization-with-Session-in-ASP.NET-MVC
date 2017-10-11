using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using AuthenticationSessionMVC.Models;
namespace AuthenticationSessionMVC.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private AccountTest AccountTest;
        private AccountModel am = new AccountModel();
        public CustomPrincipal(AccountTest accounttest)
        {
            this.AccountTest = accounttest;
            this.Identity = new GenericIdentity(accounttest.UserName);
        }
        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.AccountTest.Roles.Contains(r));

        }
    }
}