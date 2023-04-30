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

        public bool EditStatByPlayerIDSeasonIDAndStatName(Stats oldStat, Stats newStat)
        {
            bool result = false;

            try
            {
                result = (1 == _playerStatAccessor.UpdateStatByPlayerIDSeasonIDAndStatName(oldStat, newStat));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
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

        public Stats GetStatByPlayerIDSeasonIDAndStatName(Stats stats)
        {
            Stats playerStat = null;

            try
            {
                playerStat = _playerStatAccessor.SelectStatByPlayerIDSeasonIDAndStatName(stats);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return playerStat;
        }

        public bool InsertNewPlayerStat(Stats stat)
        {
            bool success = false;

            if (1 == _playerStatAccessor.InsertNewPlayerStat(stat))
            {
                success = true;
            }

            return success;
        }

        public List<string> RetrieveAllSeasonIDs()
        {
            List<string> seasonIDs = null;

            try
            {
                seasonIDs = _playerStatAccessor.SelectAllSeasonIDs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return seasonIDs;
        }

        public List<string> RetrieveAllStatNames()
        {
            List<string> statNames = null;

            try
            {
                statNames = _playerStatAccessor.SelectAllStatNames();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return statNames;
        }

        public bool RetrieveStatByPlayerIDSeasonIDAndStatName(Stats stats)
        {
            try
            {
                return _playerStatAccessor.SelectStatByPlayerIDSeasonIDAndStatName(stats) != null;
            }
            catch (ApplicationException ex)
            {
                if (ex.Message == "Stat not found.")
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ax)
            {
                throw new ApplicationException("Database Error.", ax);
            }
        }
    }
}
