using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class TeamDAL
    {
        public TeamDTO GetTeamWithID(int ID)
        {
            TeamDTO teamDTO = new TeamDTO();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("Select * From `foto` where `ID` = @ID", con);
                sqlCom.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    teamDTO.ID = reader.GetInt32("ID");
                    teamDTO.Club = reader.GetString("club");
                    teamDTO.Elftal = reader.GetString("Elftal");
                }
                con.Close();
            }

            return teamDTO;
        }

    }
}
