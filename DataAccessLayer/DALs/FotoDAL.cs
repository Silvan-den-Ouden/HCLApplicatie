using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class FotoDAL
    {
        public static List<FotoDTO> GetFotoDTOs()
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
                        ID = reader.GetInt32(0),
                        URL = reader.GetString(1),
                    };
                    fotos.Add(f);
                }
                con.Close();
            }
            return fotos;
        }
    }
}
