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
        public int InsertNewPlayerStat(int playerID, string statName, string seasonID, double statAmount)
        {
            int result = 0;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_new_player_stat";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@playerID", SqlDbType.Int);
            cmd.Parameters.Add("@statName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@seasonID", SqlDbType.NVarChar, 9);
            cmd.Parameters.Add("@statAmount", SqlDbType.Float);

            cmd.Parameters["@playerID"].Value = playerID;
            cmd.Parameters["@statName"].Value = statName;
            cmd.Parameters["@seasonID"].Value = seasonID;
            cmd.Parameters["@statAmount"].Value = statAmount;

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
    }
}
