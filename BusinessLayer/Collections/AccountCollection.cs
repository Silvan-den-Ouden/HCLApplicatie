using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DALs;
using BusinessLayer.Models;
using DataTransferObjects;

namespace BusinessLayer.Collections
{
    public class AccountCollection
    {
        private readonly AccountDAL _accountDAL = new AccountDAL();

        public List<Account> GetUsers()
        {
            List<Account> accounts = new List<Account>();

            foreach (var accountDTO in _accountDAL.GetUserInfo())
            {
                Account u = new Account()
                {
                    ID = accountDTO.ID,
                    Naam = accountDTO.Naam,
                    Email = accountDTO.Email,
                    Wachtwoord = accountDTO.Wachtwoord,
                    Team = accountDTO.Team,
                    Rol = accountDTO.Rol,
                };
                accounts.Add(u);
            }
            return accounts;
        }

        public Account GetAccountWithID(int ID)
        {
            var accountDTO = _accountDAL.GetAccountWithID(ID);
            Account account = new Account()
            {
                ID = accountDTO.ID,
                Naam = accountDTO.Naam,
                Email = accountDTO.Email,
                Wachtwoord = accountDTO.Wachtwoord,
                Team = accountDTO.Team,
                Rol = accountDTO.Rol,
            };

            return account;
        }

        //public Account loggedInUser()
        //{
        //    Account loggedInUser = new Account();

        //    foreach (var account in GetUsers())
        //    {
        //        if (account.ID == GetUID())
        //        {
        //            loggedInUser = account;
        //        }
        //    }

        //    return loggedInUser;
        //}

        ////hard-coded "logged in" user
        //public int GetUID()
        //{
        //    int account = _accountDAL.LoggedInUser();
        //    return account;
        //}

    }
}
