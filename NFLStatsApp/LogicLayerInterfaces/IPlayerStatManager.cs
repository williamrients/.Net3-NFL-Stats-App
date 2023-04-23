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
        bool InsertNewPlayerStat(int playerID, string statName, string seasonID, double statAmount);
        List<Stats> GetAllPlayerStatsByPlayerID(int playerID);
    }
}
