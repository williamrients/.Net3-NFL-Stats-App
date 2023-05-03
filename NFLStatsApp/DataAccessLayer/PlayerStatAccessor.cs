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
    public class PlayerStatAccessor : IPlayerStatAccessor
    {
        public int InsertNewPlayerStat(Stats stat)
        {
            int result = 0;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_new_player_stat";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@playerID", stat.PlayerID);
            cmd.Parameters.AddWithValue("@statName", stat.StatName);
            cmd.Parameters.AddWithValue("@seasonID", stat.SeasonID);
            cmd.Parameters.AddWithValue("@statAmount", stat.StatAmount);

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

        public List<string> SelectAllSeasonIDs()
        {
            List<string> seasonIDs = new List<string>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_seasonIDs";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        seasonIDs.Add(reader.GetString(0));
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
            return seasonIDs;
        }

        public List<string> SelectAllStatNames()
        {
            List<string> statNames = new List<string>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_statNames";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        statNames.Add(reader.GetString(0));
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
            return statNames;
        }

        public List<Stats> SelectPlayerStatsByActive(bool active)
        {
            List<Stats> allPlayerStats = new List<Stats>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_stats_by_active";

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
                        //[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount] 
                        var playerStats = new Stats();
                        playerStats.PlayerID = reader.GetInt32(0);
                        playerStats.GivenName = reader.GetString(1);
                        playerStats.FamilyName = reader.GetString(2);
                        playerStats.Active = reader.GetBoolean(3);
                        playerStats.StatName = reader.GetString(4);
                        playerStats.StatAmount = reader.GetDouble(5);
                        playerStats.SeasonID = reader.GetString(6);
                        allPlayerStats.Add(playerStats);
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

            return allPlayerStats;
        }

        public List<Stats> SelectPlayerStatsByPlayerID(int playerID)
        {
            List<Stats> allPlayerStats = new List<Stats>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_stats_by_player_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlayerId", playerID);
            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Stats playerStats = new Stats();
                        playerStats.PlayerID = reader.GetInt32(0);
                        playerStats.GivenName = reader.GetString(1);
                        playerStats.FamilyName = reader.GetString(2);
                        playerStats.Active = reader.GetBoolean(3);
                        playerStats.StatName = reader.GetString(4);
                        playerStats.StatAmount = reader.GetDouble(5);
                        playerStats.SeasonID = reader.GetString(6);
                        allPlayerStats.Add(playerStats);
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

            return allPlayerStats;
        }

        public Stats SelectStatByPlayerIDSeasonIDAndStatName(Stats stats)
        {
            Stats playerStat = null;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_stat_by_playerID_seasonID_and_statName";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@playerID", stats.PlayerID);
            cmd.Parameters.AddWithValue("@SeasonID", stats.SeasonID);
            cmd.Parameters.AddWithValue("@StatName", stats.StatName);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    playerStat = new Stats()
                    {
                        PlayerID = reader.GetInt32(0),
                        StatName = reader.GetString(1),
                        SeasonID = reader.GetString(2),
                        StatAmount = reader.GetDouble(3)
                    };
                }
                else
                {
                    throw new ApplicationException("Stat not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return playerStat;
        }

        public List<Stats> SelectStatsByStatName(string statName)
        {
            List<Stats> statList = new List<Stats>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_stats_by_statName";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StatName", statName);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Stats stats = new Stats()
                        {
                            PlayerID = reader.GetInt32(0),
                            GivenName = reader.GetString(1),
                            FamilyName = reader.GetString(2),
                            Active = reader.GetBoolean(3),
                            StatName = reader.GetString(4),
                            StatAmount = reader.GetDouble(5),
                            SeasonID = reader.GetString(6)
                    };
                        statList.Add(stats);
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
            return statList;

        }

        public int UpdateStatByPlayerIDSeasonIDAndStatName(Stats oldStat, Stats newStat)
        {
            int rows = 0;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_update_stat_by_playerID_seasonID_and_statName";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlayerID", oldStat.PlayerID);

            cmd.Parameters.AddWithValue("@SeasonID", newStat.SeasonID);
            cmd.Parameters.AddWithValue("@StatName", newStat.StatName);
            cmd.Parameters.AddWithValue("@StatAmount", newStat.StatAmount);

            cmd.Parameters.AddWithValue("@OldSeasonID", oldStat.SeasonID);
            cmd.Parameters.AddWithValue("@OldStatName", oldStat.StatName);
            cmd.Parameters.AddWithValue("@OldStatAmount", oldStat.StatAmount);

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
