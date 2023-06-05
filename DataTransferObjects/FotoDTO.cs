using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class FotoDTO
    {
        public int ID { get; set; }
        public int Account_ID { get; set; }
        public int Team_ID { get; set; }
        public int Public { get; set; }
        public string URL { get; set; }

        public FotoDTO() { }
    }
}
