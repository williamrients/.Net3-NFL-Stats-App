using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class TeamManager : ITeamsManager
    {
        private ITeamsAccessor _teamsAccessor = null;

        public TeamManager()
        {
            _teamsAccessor = new DataAccessLayer.TeamsAccessor();
        }

        public TeamManager(ITeamsAccessor teamsAccessor)
        {
            _teamsAccessor = teamsAccessor;
        }

        public List<Teams> GetAllTeamsByActive(bool active)
        {
            List<Teams> teams = null;

            try
            {
                teams = _teamsAccessor.SelectTeamsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return teams;
        }

        public List<string> RetrieveAllTeamNames()
        {
            List<string> teamNames = null;

            try
            {
                teamNames = _teamsAccessor.SelectAllTeamNames();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamNames;
        }

        public Teams RetrieveTeamByTeamName(string teamName)
        {
            try
            {
                return _teamsAccessor.SelectTeamByTeamName(teamName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateTeam(Teams oldTeam, Teams newTeam)
        {
            bool result = false;

            try
            {
                result = (1 == _teamsAccessor.UpdateTeam(oldTeam, newTeam));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
