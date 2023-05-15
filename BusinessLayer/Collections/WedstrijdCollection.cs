using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DALs;
using DataTransferObjects;
using BusinessLayer.Models;

namespace BusinessLayer.Collections
{
    public class WedstrijdCollection
    {
        private readonly WedstrijdDAL _wedstrijdDAL = new WedstrijdDAL();

        public List<Wedstrijd> GetWedstrijden()
        {
            List<Wedstrijd> wedstrijden = new List<Wedstrijd>();

            foreach (var wedstrijd in _wedstrijdDAL.GetWedstrijdInfo())
            {
                Wedstrijd w = new Wedstrijd()
                {
                    ID = wedstrijd.ID,
                    ThuisTeam = wedstrijd.ThuisTeam,
                    ThuisScore = wedstrijd.ThuisScore,
                    UitScore = wedstrijd.UitScore,
                    UitTeam = wedstrijd.UitTeam,
                    Datum = wedstrijd.Datum,
                };
                wedstrijden.Add(w);
            }

            return wedstrijden;
        }

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

            _wedstrijdDAL.CreateWedstrijd(wedstrijdDTO);
        }
    }
}
