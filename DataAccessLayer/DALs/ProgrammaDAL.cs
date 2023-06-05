using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using Interfaces;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class ProgrammaDAL : IProgramma
    {
        public List<ProgrammaDTO> GetProgrammaDTOs()
        {
            List<ProgrammaDTO> programmaDTOs = new List<ProgrammaDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM `programma` ORDER BY `DatumTijd` ASC ", con);
                MySqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    ProgrammaDTO p = new ProgrammaDTO()
                    {
                        ID = reader.GetInt32(0),
                        ThuisTeam = reader.GetString(1),
                        UitTeam = reader.GetString(2),
                        DatumTijd = reader.GetDateTime(3)
                    };
                    programmaDTOs.Add(p);
                }
                con.Close();
            }

            return programmaDTOs;
        }

        public ProgrammaDTO GetProgrammaDTOWithID(int ID)
        {
            ProgrammaDTO programmaDTO = new ProgrammaDTO();

            using(MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `programma` WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    programmaDTO.ID = reader.GetInt32(0);
                    programmaDTO.ThuisTeam = reader.GetString(1);
                    programmaDTO.UitTeam = reader.GetString(2);
                    programmaDTO.DatumTijd = reader.GetDateTime(3);
                }
                con.Close();
            }

            return programmaDTO;
        }

        public void UpdateProgramma(int ID, string ThuisTeam, string UitTeam, string DatumString)
        {
            using(MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `programma` SET `thuisTeam` = @ThuisTeam, `uitTeam` = @UitTeam, `DatumTijd` = @DatumTijd WHERE `ID` = @ID", con);
                cmd.Parameters.AddWithValue("@ThuisTeam", ThuisTeam);
                cmd.Parameters.AddWithValue("@UitTeam", UitTeam);
                cmd.Parameters.AddWithValue("@DatumTijd", DatumString);
                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void DeleteProgramma(int ID)
        {
            using(MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM `programma` WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
