using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface ITeamsAccessor
    {
        List<Teams> SelectTeamsByActive(bool active);
        int UpdateTeam(Teams oldTeam, Teams newTeam);
        Teams SelectTeamByTeamName(string teamName);
        List<string> SelectAllTeamNames();
    }
}
