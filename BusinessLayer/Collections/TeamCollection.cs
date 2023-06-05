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

        public List<TeamModel> GetTeams()
        {
            List<TeamModel> teamModels = new List<TeamModel>();

            foreach (var teamDTO in _teamDAL.GetTeamDTOs())
            {
                TeamModel t = new TeamModel()
                {
                    ID = teamDTO.ID,
                    Club = teamDTO.Club,
                    Elftal = teamDTO.Elftal,
                };
                teamModels.Add(t);
            }
            return teamModels;
        }

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
