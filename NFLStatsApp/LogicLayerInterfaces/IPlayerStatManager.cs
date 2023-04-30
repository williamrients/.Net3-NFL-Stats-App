using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IPlayerStatManager
    {
        List<Stats> GetAllPlayerStatsByActive(bool active);
        bool InsertNewPlayerStat(Stats stat);
        List<Stats> GetAllPlayerStatsByPlayerID(int playerID);
        List<string> RetrieveAllStatNames();
        List<string> RetrieveAllSeasonIDs();
        bool RetrieveStatByPlayerIDSeasonIDAndStatName(Stats stats);
        bool EditStatByPlayerIDSeasonIDAndStatName(Stats oldStat, Stats newStat);
        Stats GetStatByPlayerIDSeasonIDAndStatName(Stats stats);
    }
}
