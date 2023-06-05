using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using Interfaces;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class WedstrijdDAL : IWedstrijd
    {
        public List<WedstrijdDTO> GetWedstrijdDTOs()
        {
            List<WedstrijdDTO> wedstrijdDTOs = new List<WedstrijdDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM `wedstrijd` ORDER BY `datum` DESC", con);
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
                    wedstrijdDTOs.Add(w);
                }
                con.Close();
            }

            return wedstrijdDTOs;
        }
            
        public void CreateWedstrijd(WedstrijdDTO wedstrijdDTO)
        {
            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `wedstrijd` (`thuisTeam`,`thuisScore`, `uitScore`, `uitTeam`,`datum`) VALUES (@ThuisTeam, @ThuisScore, @UitScore, @UitTeam, @DatumTijd)", con);
                cmd.Parameters.AddWithValue("@ThuisTeam", wedstrijdDTO.ThuisTeam);
                cmd.Parameters.AddWithValue("@ThuisScore", wedstrijdDTO.ThuisScore);
                cmd.Parameters.AddWithValue("@UitScore", wedstrijdDTO.UitScore);
                cmd.Parameters.AddWithValue("@UitTeam", wedstrijdDTO.UitTeam);
                cmd.Parameters.AddWithValue("@DatumTijd", wedstrijdDTO.Datum.Year.ToString() + "-" + wedstrijdDTO.Datum.Month.ToString() + "-" + wedstrijdDTO.Datum.Day.ToString());

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

    }
}
