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
        public List<WedstrijdDTO> GetWedstrijdInfo()
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
                MySqlCommand sqlCom = new MySqlCommand("Insert into `wedstrijd` (`thuisTeam`,`thuisScore`, `uitScore`, `uitTeam`,`datum`) VALUES (@ThuisTeam, @ThuisScore, @UitScore, @UitTeam, @DatumTijd)", con);
                sqlCom.Parameters.AddWithValue("@ThuisTeam", wedstrijdDTO.ThuisTeam);
                sqlCom.Parameters.AddWithValue("@ThuisScore", wedstrijdDTO.ThuisScore);
                sqlCom.Parameters.AddWithValue("@UitScore", wedstrijdDTO.UitScore);
                sqlCom.Parameters.AddWithValue("@UitTeam", wedstrijdDTO.UitTeam);
                sqlCom.Parameters.AddWithValue("@DatumTijd", wedstrijdDTO.Datum.Year.ToString() + "-" + wedstrijdDTO.Datum.Month.ToString() + "-" + wedstrijdDTO.Datum.Day.ToString());

                MySqlDataReader reader = sqlCom.ExecuteReader();
                con.Close();
            }
        }

    }
}
