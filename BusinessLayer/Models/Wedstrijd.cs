using System;
using DataAccessLayer.DALs;
using DataAccessLayer.DTOs;

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

        public void CreateWedstrijd(Wedstrijd wedstrijd)
        {
            WedstrijdDTO wedstrijdDTO = new WedstrijdDTO()
            {
                ID = wedstrijd.ID,
                ThuisTeam = wedstrijd.ThuisTeam,
                ThuisScore = wedstrijd.ThuisScore,
                UitScore = wedstrijd.UitScore,
                UitTeam = wedstrijd.UitTeam,
                Datum = wedstrijd.Datum,
            };

            WedstrijdDAL.CreateWedstrijd(wedstrijdDTO);
        }
    }
}
