using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class FotoDAL
    {
        public List<FotoDTO> GetFotoDTOs()
        {
            List<FotoDTO> fotoDTOs = new List<FotoDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `foto`", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FotoDTO f = new FotoDTO()
                    {
                        ID = reader.GetInt32("ID"),
                        Account_ID = reader.GetInt32("account_ID"),
                        Team_ID = reader.GetInt32("team_ID"),
                        Public = reader.GetString("public"),
                        URL = reader.GetString("url"),
                    };
                    fotoDTOs.Add(f);
                }
                con.Close();
            }
            return fotoDTOs;
        }

        public List<FotoDTO> GetPublicFotos()
        {
            List<FotoDTO> fotoDTOs = new List<FotoDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `foto` WHERE `public` = \"public\"", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FotoDTO f = new FotoDTO()
                    {
                        ID = reader.GetInt32("ID"),
                        Account_ID = reader.GetInt32("account_ID"),
                        Team_ID = reader.GetInt32("team_ID"),
                        Public = reader.GetString("public"),
                        URL = reader.GetString("url"),
                    };
                    fotoDTOs.Add(f);
                }
                con.Close();
            }
            return fotoDTOs;
        }

        public List<FotoDTO> GetFotosFromTeam(int team_ID)
        {
            List<FotoDTO> fotoDTOs = new List<FotoDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `foto` WHERE `team_ID` = @Team_ID", con);
                cmd.Parameters.AddWithValue("Team_ID", team_ID);
                
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FotoDTO f = new FotoDTO()
                    {
                        ID = reader.GetInt32("ID"),
                        Account_ID = reader.GetInt32("account_ID"),
                        Team_ID = reader.GetInt32("team_ID"),
                        Public = reader.GetString("public"),
                        URL = reader.GetString("url"),
                    };
                    fotoDTOs.Add(f);
                }
                con.Close();
            }
            return fotoDTOs;
        }

        public FotoDTO GetFotoWithID(int ID)
        {
            FotoDTO fotoDTO = new FotoDTO();

            using(MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `foto` WHERE `ID` = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    fotoDTO.ID = reader.GetInt32("ID");
                    fotoDTO.Account_ID = reader.GetInt32("account_ID");
                    fotoDTO.Team_ID = reader.GetInt32("team_ID");
                    fotoDTO.Public = reader.GetString("public");
                    fotoDTO.URL = reader.GetString("url");
                }
                con.Close();
            }
            return fotoDTO;
        }

        public void ChangeFotoToPublic(int ID)
        {
            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `foto` SET `public` = \"public\" WHERE `ID` = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void ChangeFotoToPrivate(int ID)
        {
            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `foto` SET `public` = \"private\" WHERE `ID` = @ID", con);
                
                cmd.Parameters.AddWithValue("@ID", ID);
                
                cmd.ExecuteNonQuery();
                
                con.Close();
            }
        }
        
        public void DeleteFoto(int ID)
        {
            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();

                MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM `foto` WHERE `ID` = @ID", con);
                deleteCmd.Parameters.AddWithValue("@ID", ID);
                deleteCmd.ExecuteNonQuery();

                MySqlCommand getMaxIndexCmd = new MySqlCommand("SELECT MAX(`ID`) FROM `foto`", con);
                int maxIndex = Convert.ToInt32(getMaxIndexCmd.ExecuteScalar());
                
                MySqlCommand resetAutoIncrementCmd = new MySqlCommand($"ALTER TABLE `foto` AUTO_INCREMENT = {maxIndex + 1}", con);
                resetAutoIncrementCmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void UploadFoto(int account_ID, int team_ID, string publicity, string url)
        {
            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO `foto` (account_ID, team_ID, public, url) VALUES (@account_ID, @team_ID, @publicity, @url)", con);

                cmd.Parameters.AddWithValue("@account_ID", account_ID);
                cmd.Parameters.AddWithValue("@team_ID", team_ID);
                cmd.Parameters.AddWithValue("@publicity", publicity);
                cmd.Parameters.AddWithValue("@url", url);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
