using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DALs;
using BusinessLayer.Models;

namespace BusinessLayer.Collections
{
    public class AccountCollection
    {
        private readonly AccountDAL _accountDAL = new AccountDAL();

        public List<Account> GetUsers()
        {
            List<Account> accounts = new List<Account>();

            foreach (var user in _accountDAL.GetUserInfo())
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

        public Account loggedInUser()
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
        public int GetUID()
        {
            int account = _accountDAL.LoggedInUser();
            return account;
        }

    }
}
