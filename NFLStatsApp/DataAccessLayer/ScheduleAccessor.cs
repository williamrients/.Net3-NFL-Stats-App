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
    public class ScheduleAccessor : IScheduleAccessor
    {
        public List<int> SelectDistinctWeeks()
        {
            List<int> weekList = new List<int>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_distinct_weeks";

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
                        weekList.Add(reader.GetInt32(0));
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
            return weekList;
        }

        public List<Schedule> SelectScheduleBySeasonIDAndWeekNumber(string seasonID, int weekNumber)
        {
            List<Schedule> scheduleList = new List<Schedule>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_schedule_by_season_and_week";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SeasonID", seasonID);
            cmd.Parameters.AddWithValue("@WeekNumber", weekNumber);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Schedule schedule = new Schedule()
                        {
                            GameID = reader.GetInt32(0),
                            TeamNameAway = reader.GetString(1),
                            TeamNameHome = reader.GetString(2),
                            TeamAwayScore = reader.GetInt32(3),
                            TeamHomeScore = reader.GetInt32(4),
                            WeekNumber = reader.GetInt32(5),
                            SeasonID = reader.GetString(6),
                            OverTime = reader.GetBoolean(7),
                            GameDate = reader.GetDateTime(8)
                        };
                        scheduleList.Add(schedule);
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
            return scheduleList;
        }
    }
}
