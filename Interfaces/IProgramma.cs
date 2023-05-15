using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace Interfaces
{
    public interface IProgramma
    {
        List<ProgrammaDTO> GetProgrammaDTOs();
        ProgrammaDTO GetProgrammaDTOWithID(int ID);
        void UpdateProgramma(int ID, string ThuisTeam, string UitTeam, string DatumString); 
        void DeleteProgramma(int ID);
    }
}
