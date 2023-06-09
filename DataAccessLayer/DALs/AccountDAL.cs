﻿using System;
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
        public List<AccountDTO> GetAccountDTOs()
        {
            List<AccountDTO> accountDTOs = new List<AccountDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM `account`", con);
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
                    accountDTOs.Add(u);
                }
                con.Close();
            }
            return accountDTOs;
        }

        public AccountDTO GetAccountWithID(int ID)
        {
            AccountDTO account = new AccountDTO();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM `account` WHERE `ID` = @ID", con);
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
    }
}
