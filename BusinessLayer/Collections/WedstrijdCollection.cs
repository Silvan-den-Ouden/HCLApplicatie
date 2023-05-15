using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DALs;
using DataTransferObjects;
using BusinessLayer.Models;
using Interfaces;

namespace BusinessLayer.Collections
{
    public class WedstrijdCollection
    {
        private readonly WedstrijdDAL _wedstrijdDAL = new WedstrijdDAL();
        private readonly IWedstrijdFactory _wedstrijdFactory;

        public WedstrijdCollection(IWedstrijdFactory wedstrijdFactory)
        {
            _wedstrijdFactory = wedstrijdFactory;
        }

        public List<Wedstrijd> GetWedstrijden()
        {
            List<Wedstrijd> wedstrijden = new List<Wedstrijd>();
            IWedstrijd wedstrijdInterface = _wedstrijdFactory.CreateWedstrijd();

            foreach (var wedstrijd in wedstrijdInterface.GetWedstrijdInfo())
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
