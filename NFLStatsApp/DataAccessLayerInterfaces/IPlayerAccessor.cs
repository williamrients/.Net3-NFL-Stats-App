using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IPlayerAccessor
    {
        List<Players> SelectPlayersByActive(bool active);
        int InsertNewPlayer(string firstName, string lastName, string yearDrafted, string teamName);
        List<Players> SelectPlayersByTeamName(string teamName);
        Players SelectPlayerByPlayerID(int playerID);
        int UpdatePlayerTeamByPlayerID(Players oldPlayer, Players newPlayer);
    }
}
