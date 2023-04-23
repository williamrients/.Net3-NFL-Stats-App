using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface ITeamsManager
    {
        List<Teams> GetAllTeamsByActive(bool active);
        bool UpdateTeam(Teams oldTeam, Teams newTeam);
        Teams RetrieveTeamByTeamName(string teamName);
        List<string> RetrieveAllTeamNames();
    }
}
