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
    public class TeamsAccessor : ITeamsAccessor
    {
        public List<string> SelectAllTeamNames()
        {
            List<string> teamNames = new List<string>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_team_names";

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
                        teamNames.Add(reader.GetString(0));
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
            return teamNames;
        }

        public Teams SelectTeamByTeamName(string teamName)
        {
            Teams team = new Teams();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_team_by_team_name";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TeamName", teamName);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    team.TeamName = reader.GetString(0);
                    team.TeamMascot = reader.GetString(1);
                    team.TeamCity = reader.GetString(2);
                    team.TeamState = reader.GetString(3);
                    team.TeamAbbrivation = reader.GetString(4);
                    team.Active = reader.GetBoolean(5);
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
            return team;
        }

        public List<Teams> SelectTeamsByActive(bool active)
        {
            List<Teams> allTeams = new List<Teams>();

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_active_teams";

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
                        // [teamName], [teamMascot], [teamCity], [teamState] [active]
                        var teams = new Teams();
                        teams.TeamName = reader.GetString(0);
                        teams.TeamMascot = reader.GetString(1);
                        teams.TeamCity = reader.GetString(2);
                        teams.TeamState = reader.GetString(3);
                        teams.TeamAbbrivation = reader.GetString(4);
                        teams.Active = reader.GetBoolean(5);
                        allTeams.Add(teams);
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

            return allTeams;
        }

        public int UpdateTeam(Teams oldTeam, Teams newTeam)
        {
            int rows = 0;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_update_team_by_team_name";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TeamName", oldTeam.TeamName);

            cmd.Parameters.AddWithValue("@TeamMascot", newTeam.TeamMascot);
            cmd.Parameters.AddWithValue("@TeamCity", newTeam.TeamCity);
            cmd.Parameters.AddWithValue("@TeamState", newTeam.TeamState);

            cmd.Parameters.AddWithValue("@OldTeamMascot", oldTeam.TeamMascot);
            cmd.Parameters.AddWithValue("@OldTeamCity", oldTeam.TeamCity);
            cmd.Parameters.AddWithValue("@OldTeamState", oldTeam.TeamState);

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
