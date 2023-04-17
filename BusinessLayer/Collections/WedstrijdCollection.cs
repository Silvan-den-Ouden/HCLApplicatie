using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DALs;
using BusinessLayer.Models;

namespace BusinessLayer.Collections
{
    public class WedstrijdCollection
    { 
        public static List<Wedstrijd> GetWedstrijden()
        {
            List<Wedstrijd> wedstrijden = new List<Wedstrijd>();

            foreach (var wedstrijd in WedstrijdDAL.GetWedstrijdInfo())
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
    }
}
