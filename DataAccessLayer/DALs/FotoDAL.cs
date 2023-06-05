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
                MySqlCommand sqlCom = new MySqlCommand("Select * From `foto`", con);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    FotoDTO f = new FotoDTO()
                    {
                        ID = reader.GetInt32("ID"),
                        Account_ID = reader.GetInt32("account_ID"),
                        Team_ID = reader.GetInt32("team_ID"),
                        Public = reader.GetInt32("public"),
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
                MySqlCommand sqlCom = new MySqlCommand("Select * From `foto` where `ID` = @ID", con);
                sqlCom.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    fotoDTO.ID = reader.GetInt32("ID");
                    fotoDTO.Account_ID = reader.GetInt32("account_ID");
                    fotoDTO.Team_ID = reader.GetInt32("team_ID");
                    fotoDTO.Public = reader.GetInt32("public");
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
                MySqlCommand cmd = new MySqlCommand("Update `foto` set `public` = 1 where `ID` = @ID", con);
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
                MySqlCommand cmd = new MySqlCommand("Update `foto` set `public` = 0 where `ID` = @ID", con);
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
    }
}
