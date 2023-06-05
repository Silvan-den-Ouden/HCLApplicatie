using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class FotoModel
    {
        public int ID { get; set; }
        public int Account_ID { get; set; }
        public int Team_ID { get; set; }
        public int Public { get; set; }
        public string URL { get; set; }

        public FotoModel() { }
    }
}
