﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class PlayerManager : IPlayerManager
    {
        private IPlayerAccessor _playerAccessor = null;

        public PlayerManager()
        {
            _playerAccessor = new DataAccessLayer.PlayerAccessor();
        }
        
        public PlayerManager(IPlayerAccessor playerAccessor)
        {
            _playerAccessor = playerAccessor;
        }

        public bool EditPlayerTeamByPlayerID(Players oldPlayer, Players newPlayer)
        {
            bool result = false;

            try
            {
                result = (1 == _playerAccessor.UpdatePlayerTeamByPlayerID(oldPlayer, newPlayer));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Players> GetAllPlayersByActive(bool active)
        {
            List<Players> players = null;

            try
            {
                players = _playerAccessor.SelectPlayersByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
            return players;
        }

        public List<Players> GetAllPlayersByTeamName(string teamName)
        {
            List<Players> players = null;

            try
            {
                players = _playerAccessor.SelectPlayersByTeamName(teamName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return players; 
        }

        public Players GetPlayerByPlayerID(int playerID)
        {
            Players player = new Players();

            try
            {
                player = _playerAccessor.SelectPlayerByPlayerID(playerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return player;
        }

        public bool InsertNewPlayer(string firstName, string lastName, string yearDrafted, string teamName)
        {
            bool success = false;

            try
            {
                if (1 == _playerAccessor.InsertNewPlayer(firstName, lastName, yearDrafted, teamName))
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return success;
        }
    }
}
