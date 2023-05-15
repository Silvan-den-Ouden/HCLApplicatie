using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.DALs
{
    public class ProgrammaDAL
    {
        public List<ProgrammaDTO> GetProgrammaDTOs()
        {
            List<ProgrammaDTO> programmaDTOs = new List<ProgrammaDTO>();

            using (MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand("Select * from `programma` order by `DatumTijd` ASC ", con);
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
                MySqlCommand sqlCom = new MySqlCommand($"Select * from `programma` where ID = {ID}", con);
                MySqlDataReader reader = sqlCom.ExecuteReader();

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
                MySqlCommand cmd = new MySqlCommand("Update `programma` set `thuisTeam` = @ThuisTeam, `uitTeam` = @UitTeam, `DatumTijd` = @DatumTijd where `ID` = @ID", con);
                cmd.Parameters.AddWithValue("@ThuisTeam", ThuisTeam);
                cmd.Parameters.AddWithValue("@UitTeam", UitTeam);
                cmd.Parameters.AddWithValue("@DatumTijd", DatumString);
                cmd.Parameters.AddWithValue("@ID", ID);

                MySqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }

        public void DeleteProgramma(int ID)
        {
            using(MySqlConnection con = ConnectorClass.MakeConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"Delete from `programma` where `id` = {ID}", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                con.Close();
            }
        }
    }
}
