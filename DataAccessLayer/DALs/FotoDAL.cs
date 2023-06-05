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
            List<FotoDTO> fotos = new List<FotoDTO>();

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
                    fotos.Add(f);
                }
                con.Close();
            }
            return fotos;
        }

        public FotoDTO GetFotoWithID(int ID)
        {
            FotoDTO foto = new FotoDTO();

            using(MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("Select * From `foto` where `ID` = @ID", con);
                sqlCom.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    foto.ID = reader.GetInt32("ID");
                    foto.Account_ID = reader.GetInt32("account_ID");
                    foto.Team_ID = reader.GetInt32("team_ID");
                    foto.Public = reader.GetInt32("public");
                    foto.URL = reader.GetString("url");
                }
                con.Close();
            }
            return foto;
        }
    }
}
