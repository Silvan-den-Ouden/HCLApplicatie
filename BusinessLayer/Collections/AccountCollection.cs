using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DALs;
using HCLApplicatie2.Models;

namespace BusinessLayer.Collections
{
    public class AccountCollection
    {
        public static List<Account> GetUsers()
        {
            List<Account> accounts = new List<Account>();

            foreach (var user in AccountDAL.GetUserInfo())
            {
                Account u = new Account()
                {
                    ID = user.ID,
                    Naam = user.Naam,
                    Email = user.Email,
                    Wachtwoord = user.Wachtwoord,
                    Team = user.Team,
                    Rol = user.Rol,
                };
                accounts.Add(u);
            }
            return accounts;
        }

        public static Account loggedInUser()
        {
            Account loggedInUser = new Account();

            foreach (var account in GetUsers())
            {
                if (account.ID == GetUID())
                {
                    loggedInUser = account;
                }
            }

            return loggedInUser;
        }

        //hard-coded "logged in" user
        public static int GetUID()
        {
            int account = AccountDAL.LoggedInUser();
            return account;
        }

    }
}
