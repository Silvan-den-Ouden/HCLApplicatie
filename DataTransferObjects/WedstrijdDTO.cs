using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class WedstrijdDTO
    {
        public int ID { get; set; }
        public string ThuisTeam { get; set; }
        public int ThuisScore { get; set; }
        public int UitScore { get; set; }
        public string UitTeam { get; set; }
        public DateTime Datum { get; set; }

        public WedstrijdDTO() { }
    }
}
