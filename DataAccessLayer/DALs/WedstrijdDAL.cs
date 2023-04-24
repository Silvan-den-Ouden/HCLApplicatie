using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DTOs;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class WedstrijdDAL
    {
        public static List<WedstrijdDTO> GetWedstrijdInfo()
        {
            List<WedstrijdDTO> wedstrijden = new List<WedstrijdDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("Select * from `wedstrijd` order by `datum` DESC", con);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    WedstrijdDTO w = new WedstrijdDTO()
                    {
                        ID = reader.GetInt32(0),
                        ThuisTeam = reader.GetString(1),
                        ThuisScore = reader.GetInt32(2),
                        UitScore = reader.GetInt32(3),
                        UitTeam = reader.GetString(4),
                        Datum = reader.GetDateTime(5)
                    };
                    wedstrijden.Add(w);
                }
                con.Close();
            }

            return wedstrijden;
        }
            
        public static void CreateWedstrijd(WedstrijdDTO wedstrijdDTO)
        {
            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand($"Insert into `wedstrijd` (`thuisTeam`,`thuisScore`, `uitScore`, `uitTeam`,`datum`) VALUES (\"{wedstrijdDTO.ThuisTeam}\", {wedstrijdDTO.ThuisScore}, {wedstrijdDTO.UitScore}, \"{wedstrijdDTO.UitTeam}\", '{wedstrijdDTO.Datum.Year}-{wedstrijdDTO.Datum.Month}-{wedstrijdDTO.Datum.Day}')", con);
                MySqlDataReader reader = sqlCom.ExecuteReader();
                con.Close();
            }
        }

    }
}
