using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using BusinessLayer.Models;
using Interfaces;
using Factory;

namespace BusinessLayer.Collections
{
    public class WedstrijdCollection
    {
       
        private readonly WedstrijdFactory _wedstrijdFactory = new WedstrijdFactory();

        public List<Wedstrijd> GetWedstrijden()
        {
            IWedstrijd _wedstrijdDAL = _wedstrijdFactory.CreateWedstrijdDAL();
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
            IWedstrijd _wedstrijdDAL = _wedstrijdFactory.CreateWedstrijdDAL();

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
