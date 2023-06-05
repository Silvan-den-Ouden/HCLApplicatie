using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataAccessLayer.DALs;

namespace BusinessLayer.Collections
{
    public class TeamCollection
    {
        private readonly TeamDAL _teamDAL = new TeamDAL();

        public TeamModel GetTeamWithID(int ID)
        {
            var teamDTO = _teamDAL.GetTeamWithID(ID);
            TeamModel teamModel = new TeamModel()
            {
                ID = teamDTO.ID,
                Club = teamDTO.Club,
                Elftal = teamDTO.Elftal,
            };

            return teamModel;
        }

    }
}
