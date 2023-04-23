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
    public class PlayerStatManager : IPlayerStatManager
    {
        private IPlayerStatAccessor _playerStatAccessor = null;

        public PlayerStatManager()
        {
            _playerStatAccessor = new DataAccessLayer.PlayerStatAccessor();
        }

        public PlayerStatManager(IPlayerStatAccessor playerStatAccessor)
        {
            _playerStatAccessor = playerStatAccessor;
        }

        public List<Stats> GetAllPlayerStatsByActive(bool active)
        {
            List<Stats> playerStats = null;

            try
            {
                playerStats = _playerStatAccessor.SelectPlayerStatsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
            return playerStats;
        }

        public List<Stats> GetAllPlayerStatsByPlayerID(int playerID)
        {
            List<Stats> playerStats = null;

            try
            {
                playerStats = _playerStatAccessor.SelectPlayerStatsByPlayerID(playerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return playerStats;
        }

        public bool InsertNewPlayerStat(int playerID, string statName, string seasonID, double statAmount)
        {
            bool success = false;

            if (1 == _playerStatAccessor.InsertNewPlayerStat(playerID, statName, seasonID, statAmount))
            {
                success = true;
            }

            return success;
        }
    }
}
