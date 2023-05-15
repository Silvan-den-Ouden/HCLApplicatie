using System;

namespace BusinessLayer.Models
{
    public class Wedstrijd
    {
        public int ID { get; set; }
        public string ThuisTeam { get; set; }
        public int ThuisScore { get; set; }
        public int UitScore { get; set; }
        public string UitTeam { get; set; }
        public DateTime Datum { get; set; }

        public Wedstrijd() { }
    }
}
