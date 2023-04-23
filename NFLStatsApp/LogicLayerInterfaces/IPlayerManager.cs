using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IPlayerManager
    {
        List<Players> GetAllPlayersByActive(bool active);
        bool InsertNewPlayer(string firstName, string lastName, string yearDrafted, string teamName);
        List<Players> GetAllPlayersByTeamName(string teamName);
    }
}
