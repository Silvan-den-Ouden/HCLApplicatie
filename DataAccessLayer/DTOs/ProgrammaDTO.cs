using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class ProgrammaDTO
    {
        public int ID { get; set; }
        public string ThuisTeam { get; set; }
        public string UitTeam { get; set; }
        public DateTime DatumTijd { get; set; }

        public ProgrammaDTO() { }
    }
}
