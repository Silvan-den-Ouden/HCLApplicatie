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
                        ID = reader.GetInt32(0),
                        Naam = reader.GetString(1),
                        Email = reader.GetString(2),
                        Wachtwoord = reader.GetString(3),
                        Team = reader.GetString(4),
                        Rol = reader.GetString(5),
                    };
                    users.Add(u);
                }
                con.Close();
            }
            return users;
        }

        public int LoggedInUser()
        {
            int UID = 2;
            return UID;
        }
    }
}
