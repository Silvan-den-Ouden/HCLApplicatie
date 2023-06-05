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
        public List<TeamDTO> GetTeamDTOs()
        {
            List<TeamDTO> teamDTOs = new List<TeamDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `team`", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TeamDTO t = new TeamDTO()
                    {
                        ID = reader.GetInt32("ID"),
                        Club = reader.GetString("club"),
                        Elftal = reader.GetString("elftal")
                    };
                    teamDTOs.Add(t);
                }
                con.Close();
            }
            return teamDTOs;
        }


        public TeamDTO GetTeamWithID(int ID)
        {
            TeamDTO teamDTO = new TeamDTO();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM `team` WHERE `ID` = @ID", con);
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
