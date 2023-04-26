using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class PlayerAccessor : IPlayerAccessor
    {
        public int InsertNewPlayer(string firstName, string lastName, string yearDrafted, string teamName)
        {
            int result = 0;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_new_player";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@givenName", firstName);
            cmd.Parameters.AddWithValue("@familyName", lastName);
            cmd.Parameters.AddWithValue("@yearDrafted", yearDrafted);
            cmd.Parameters.AddWithValue("@teamName", teamName);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public Players SelectPlayerByPlayerID(int playerID)
        {
            Players player = new Players();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_player_by_player_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlayerID", playerID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    player.PlayerID = reader.GetInt32(0);
                    player.GivenName = reader.GetString(1);
                    player.FamilyName = reader.GetString(2);
                    player.YearDrafted = reader.GetString(3);
                    player.Active = reader.GetBoolean(4);
                    player.TeamName = reader.GetString(5);
                    player.EspnID = reader.IsDBNull(6) ? null : reader.GetString(6);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return player;
        }

        public List<Players> SelectPlayersByActive(bool active)
        {
            List<Players> allPlayers = new List<Players>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_active_players";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@active", SqlDbType.Bit);

            cmd.Parameters["@active"].Value = active;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // [playerID], [givenName], [familyName], [yearDrafted], [active]
                        var player = new Players();
                        player.PlayerID = reader.GetInt32(0);
                        player.GivenName = reader.GetString(1);
                        player.FamilyName = reader.GetString(2);
                        player.YearDrafted = reader.GetString(3);
                        player.Active = reader.GetBoolean(4);
                        player.TeamName = reader.GetString(5);
                        player.EspnID = reader.IsDBNull(6) ? null : reader.GetString(6);
                        allPlayers.Add(player);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return allPlayers;
        }

        public List<Players> SelectPlayersByTeamName(string teamName)
        {
            List<Players> playerList = new List<Players>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_players_by_team_name";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TeamName", teamName);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Players players = new Players();
                        players.PlayerID = reader.GetInt32(0);
                        players.GivenName = reader.GetString(1);
                        players.FamilyName = reader.GetString(2);
                        players.YearDrafted = reader.GetString(3);
                        players.Active = reader.GetBoolean(4);
                        players.TeamName = reader.GetString(5);
                        players.EspnID = reader.IsDBNull(6) ? null : reader.GetString(6);

                        playerList.Add(players);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return playerList;
        }

        public int UpdatePlayerTeamByPlayerID(Players oldPlayer, Players newPlayer)
        {
            int rows = 0;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_update_player_team_by_playerID";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlayerID", oldPlayer.PlayerID);

            cmd.Parameters.AddWithValue("@TeamName", newPlayer.TeamName);

            cmd.Parameters.AddWithValue("@OldTeamName", oldPlayer.TeamName);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
    }
}
