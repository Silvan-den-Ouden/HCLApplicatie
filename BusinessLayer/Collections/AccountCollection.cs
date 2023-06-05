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

        public List<AccountModel> GetAccounts()
        {
            List<AccountModel> accountModels = new List<AccountModel>();

            foreach (var accountDTO in _accountDAL.GetAccountDTOs())
            {
                AccountModel u = new AccountModel()
                {
                    ID = accountDTO.ID,
                    Naam = accountDTO.Naam,
                    Email = accountDTO.Email,
                    Wachtwoord = accountDTO.Wachtwoord,
                    Team = accountDTO.Team,
                    Rol = accountDTO.Rol,
                };
                accountModels.Add(u);
            }
            return accountModels;
        }

        public AccountModel GetAccountWithID(int ID)
        {
            var accountDTO = _accountDAL.GetAccountWithID(ID);
            AccountModel accountModel = new AccountModel()
            {
                ID = accountDTO.ID,
                Naam = accountDTO.Naam,
                Email = accountDTO.Email,
                Wachtwoord = accountDTO.Wachtwoord,
                Team = accountDTO.Team,
                Rol = accountDTO.Rol,
            };

            return accountModel;
        }
    }
}
