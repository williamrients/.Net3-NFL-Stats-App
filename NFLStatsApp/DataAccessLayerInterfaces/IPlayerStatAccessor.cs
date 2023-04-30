using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IPlayerStatAccessor
    {
        List<Stats> SelectPlayerStatsByActive(bool active);
        int InsertNewPlayerStat(Stats stat);
        List<Stats> SelectPlayerStatsByPlayerID(int playerID);
        List<string> SelectAllStatNames();
        List<string> SelectAllSeasonIDs();
        Stats SelectStatByPlayerIDSeasonIDAndStatName(Stats stats);
        int UpdateStatByPlayerIDSeasonIDAndStatName(Stats oldStat, Stats newStat);
    }
}
