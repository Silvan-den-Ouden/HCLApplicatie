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

        public List<WedstrijdModel> GetWedstrijden()
        {
            IWedstrijd _wedstrijdDAL = _wedstrijdFactory.CreateWedstrijdDAL();
            List<WedstrijdModel> wedstrijden = new List<WedstrijdModel>();

            foreach (var wedstrijd in _wedstrijdDAL.GetWedstrijdInfo())
            {
                WedstrijdModel w = new WedstrijdModel()
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

        public void CreateWedstrijd(WedstrijdModel wedstrijd)
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
