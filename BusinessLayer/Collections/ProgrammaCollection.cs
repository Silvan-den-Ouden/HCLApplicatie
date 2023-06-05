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
        private readonly ProgrammaDAL _programmaDAL = new ProgrammaDAL();

        public List<ProgrammaModel> GetProgramma()
        {
            List<ProgrammaModel> programmaModels = new List<ProgrammaModel>();

            foreach (var programmaDTO in _programmaDAL.GetProgrammaDTOs())
            {
                ProgrammaModel p = new ProgrammaModel()
                {
                    ID = programmaDTO.ID,
                    ThuisTeam = programmaDTO.ThuisTeam,
                    UitTeam = programmaDTO.UitTeam,
                    DatumTijd = programmaDTO.DatumTijd,
                };
                programmaModels.Add(p);
            }

            return programmaModels;
        }

        public ProgrammaModel GetProgrammaWithID(int ID)
        {
            var programmaDTO = _programmaDAL.GetProgrammaDTOWithID(ID);
            ProgrammaModel programmaModel = new ProgrammaModel()
            {
                ID = programmaDTO.ID,
                ThuisTeam = programmaDTO.ThuisTeam,
                UitTeam = programmaDTO.UitTeam,
                DatumTijd = programmaDTO.DatumTijd,
            };
            
            return programmaModel;
        }

        public void UpdateProgramma(int ID, string ThuisTeam, string UitTeam, DateTime Datum)
        {
            string DatumString = $"{Datum.Year}-{Datum.Month}-{Datum.Day}";
            string TijdString = $"{Datum.TimeOfDay}";
            DatumString += " " + TijdString;

            _programmaDAL.UpdateProgramma(ID, ThuisTeam, UitTeam, DatumString);
        }

        public void DeleteProgramma(int ID)
        {
            _programmaDAL.DeleteProgramma(ID);
        }
    }
}
