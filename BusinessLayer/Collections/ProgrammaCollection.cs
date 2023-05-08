using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataAccessLayer.DALs;

namespace BusinessLayer.Collections
{
    public class ProgrammaCollection
    {
        public static List<ProgrammaModel> GetProgramma()
        {
            List<ProgrammaModel> programmaList = new List<ProgrammaModel>();

            foreach (var programmaItem in ProgrammaDAL.GetProgrammaDTOs())
            {
                ProgrammaModel p = new ProgrammaModel()
                {
                    ID = programmaItem.ID,
                    ThuisTeam = programmaItem.ThuisTeam,
                    UitTeam = programmaItem.UitTeam,
                    DatumTijd = programmaItem.DatumTijd,
                };
                programmaList.Add(p);
            }

            return programmaList;
        }

        public static ProgrammaModel GetProgrammaWithID(int ID)
        {
            var programmaDTO = ProgrammaDAL.GetProgrammaDTOWithID(ID);
            ProgrammaModel programma = new ProgrammaModel()
            {
                ID = programmaDTO.ID,
                ThuisTeam = programmaDTO.ThuisTeam,
                UitTeam = programmaDTO.UitTeam,
                DatumTijd = programmaDTO.DatumTijd,
            };
            
            return programma;
        }

        public static void UpdateProgramma(int ID, string ThuisTeam, string UitTeam, DateTime Datum)
        {
            string DatumString = $"{Datum.Year}-{Datum.Month}-{Datum.Day}";
            string TijdString = $"{Datum.TimeOfDay}";
            DatumString += " " + TijdString;

            ProgrammaDAL.UpdateProgramma(ID, ThuisTeam, UitTeam, DatumString);
        }
    }
}
