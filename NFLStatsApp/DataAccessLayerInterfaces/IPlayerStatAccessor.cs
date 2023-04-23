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
        int InsertNewPlayerStat(int playerID, string statName, string seasonID, double statAmount);
        List<Stats> SelectPlayerStatsByPlayerID(int playerID);
    }
}
