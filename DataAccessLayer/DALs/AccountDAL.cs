using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class AccountDAL
    {
        public List<AccountDTO> GetUserInfo()
        {
            List<AccountDTO> users = new List<AccountDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("Select * From `account`", con);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    AccountDTO u = new AccountDTO()
                    {
                        ID = reader.GetInt32("ID"),
                        Naam = reader.GetString("naam"),
                        Email = reader.GetString("email"),
                        Wachtwoord = reader.GetString("wachtwoord"),
                        Team = reader.GetString("team"),
                        Rol = reader.GetString("rol"),
                    };
                    users.Add(u);
                }
                con.Close();
            }
            return users;
        }

        public AccountDTO GetAccountWithID(int ID)
        {
            AccountDTO account = new AccountDTO();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("Select * From `account` where `ID` = @ID", con);
                sqlCom.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    account.ID = reader.GetInt32("ID");
                    account.Naam = reader.GetString("naam");
                    account.Email = reader.GetString("email");
                    account.Wachtwoord = reader.GetString("wachtwoord");
                    account.Team = reader.GetString("team");
                    account.Rol = reader.GetString("rol");
                }
                con.Close();
            }
            return account;
        }

        //public int LoggedInUser()
        //{
        //    int UID = 2;
        //    return UID;
        //}
    }
}
