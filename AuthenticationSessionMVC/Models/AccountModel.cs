using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationSessionMVC.Models
{
    public class AccountModel
    {
        private List<AccountTest> listAccounts = new List<AccountTest>();

        public AccountModel()
        {
            listAccounts.Add(new AccountTest { UserName = "a1", Password = "a1", Roles = new string[] { "superadmin", "admin", "employee" } });
            listAccounts.Add(new AccountTest { UserName = "a2", Password = "a2", Roles = new string[] { "admin", "employee" } });
            listAccounts.Add(new AccountTest { UserName = "a3", Password = "a3", Roles = new string[] { "employee" } });

        }
        public AccountTest Find(string username)
        {
            return listAccounts.Where(acc => acc.UserName.Equals(username)).FirstOrDefault();
        }
        public AccountTest Login(string username,string password)
        {
            return listAccounts.Where(acc => acc.UserName.Equals(username)&& acc.Password.Equals(password)).FirstOrDefault();
        }
    }
}