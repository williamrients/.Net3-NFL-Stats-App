USE [Football_Stats_db]

print '' print '*** CREATING STORED PROCEDURES'

print '' print '*** creating sp_check_user'
GO
CREATE PROCEDURE [dbo].[sp_check_user]
(
	@email			[nvarchar](100),
	@PasswordHash	[nvarchar](100)
)
AS
	BEGIN
		SELECT COUNT([userID]) AS 'Checked'
		FROM		[users]
		WHERE		@email = [email]
			AND		@PasswordHash = [PasswordHash]
			AND		[Active] = 1
	END
GO

print '' print '*** creating sp_select_users_by_email'
GO
CREATE PROCEDURE [dbo].[sp_select_users_by_email]
(
	@email 			[nvarchar](100)
)
AS	
	BEGIN
		SELECT [userID], [GivenName], [FamilyName], 
				[Phone], [email], [Active]
		FROM	[Users]
		WHERE	@email = [email]
	END     
GO  

print '' print '*** creating sp_select_roles_by_userID'
GO
CREATE PROCEDURE [dbo].[sp_select_roles_by_userID]
(
	@userID			[int]
)
AS
	BEGIN
		SELECT 	[RoleID]
		FROM	[userRole]
		WHERE	@userID = [userID]
	END
GO

print '' print '** creating sp_update_passwordHash'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordHash]
(
	@userID					[int],
	@PasswordHash			[nvarchar](100),
	@OldPasswordHash		[nvarchar](100)
)
AS
	BEGIN
		UPDATE	[users]
		  SET	[PasswordHash] = 	@PasswordHash
		WHERE	@userID = [userID]
		  AND	@OldPasswordHash = 	[PasswordHash]
		  
		RETURN 	@@ROWCOUNT
	END
GO

print '' print '** creating sp_select_users_by_active'
GO
CREATE PROCEDURE [dbo].[sp_select_users_by_active]
(
	@active		[bit]
)
AS
	BEGIN
		SELECT	[users].[userID], [givenName], [familyName], [phone], [email], [role].[roleID]
		FROM	[users] JOIN [userRole]
				ON [users].[userID] = [userRole].[userID] JOIN [role] 
				ON [role].[roleID] = [userRole].[roleID]
		WHERE	@active = [active]
	END
GO

print '' print '** creating sp_insert_new_user_and_role'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_user_and_role]
(
	@givenName	[nvarchar] (50),
	@familyName [nvarchar] (100),
	@phone		[nvarchar] (13),
	@email		[nvarchar] (100),
	@roleID		[nvarchar] (50)
)
AS
	BEGIN
		DECLARE @userid [int]
		
		INSERT INTO [dbo].[users]
		([givenName], [familyName], [phone], [email])
		VALUES
		(@givenName, @familyName, @phone, @email)
		
		SET @userid = scope_identity()
		
		INSERT INTO [dbo].[userRole]
		([userid], [roleID])
		VALUES
		(@userid, @roleID)
	END
GO

print '' print '** creating sp_insert_new_user'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_user]
(
	@givenName	[nvarchar] (50),
	@familyName [nvarchar] (100),
	@phone		[nvarchar] (13),
	@email		[nvarchar] (100)
)
AS
	BEGIN
		INSERT INTO [dbo].[users]
		([givenName], [familyName], [phone], [email])
		VALUES
		(@givenName, @familyName, @phone, @email)
		
		RETURN 	@@ROWCOUNT
		
	END
GO

print '' print '** creating sp_select_all_roles'
GO
CREATE PROCEDURE [dbo].[sp_select_all_roles]
AS
	BEGIN
		SELECT	[roleID]
		FROM	[role]
	END
GO


print '' print '*** Creating sp_delete_user_role'
GO
CREATE PROCEDURE [sp_delete_user_role]
(
	@userid			[int],
	@roleID			[nvarchar](50)
)
AS
	BEGIN
		DELETE FROM [dbo].[userRole]
		WHERE [userid] =	@userid
		AND [RoleID] = 	@RoleID
	END
GO

print '' print '*** Creating sp_insert_user_role'
GO
CREATE PROCEDURE [sp_insert_user_role]
(
	@userid			[int],
	@roleID			[nvarchar](50)
)
AS
	BEGIN
		INSERT INTO [dbo].[userRole]
		([userid], [RoleID])
		VALUES
		(@userid, @roleID)
	END
GO

print '' print '*** creating sp_select_all_active_teams'
GO
CREATE PROCEDURE [dbo].[sp_select_all_active_teams]
(
	@active		[bit]
)
AS
	BEGIN
		SELECT	[teamName], [teamMascot], [teamCity], [teamState], [teamAbbreviation], [active]
		FROM	[team]
		WHERE	@active = [active]
	END
GO

print '' print '*** Creating sp_update_team_by_team_name'
GO
CREATE PROCEDURE sp_update_team_by_team_name
	(
		@TeamName			[nvarchar] (50),
		
		@TeamMascot			[nvarchar] (50),
		@TeamCity           [nvarchar] (50),
		@TeamState          [nvarchar] (50),
		
		@OldTeamMascot		[nvarchar] (50),
		@OldTeamCity        [nvarchar] (50),
		@OldTeamState       [nvarchar] (50)
	)
AS
	BEGIN
		UPDATE 	[Team]
		SET		[TeamMascot] = 	@TeamMascot,
				[TeamCity] =	@TeamCity,
				[TeamState] = 	@TeamState
		WHERE	[TeamName] = 	@TeamName
		AND		[TeamMascot] = 	@OldTeamMascot
		AND		[TeamCity] =	@OldTeamCity
		AND		[TeamState] = 	@OldTeamState
		
		RETURN @@ROWCOUNT
	END
GO		
		
print '' print '*** Creating sp_select_team_by_team_name'
GO
CREATE PROCEDURE sp_select_team_by_team_name
	(
		@TeamName 		[nvarchar] (50)
	)
AS
	BEGIN
		SELECT	[teamName], [teamMascot], [teamCity], [teamState], [teamAbbreviation], [active]
		FROM	[team]
		WHERE	@TeamName = [TeamName]
	END
GO

print '' print '*** creating sp_select_all_team_names'
GO
CREATE PROCEDURE [dbo].[sp_select_all_team_names]
AS
	BEGIN
		SELECT	[TeamName]
		FROM	[Team]
	END
GO

print '' print '*** creating sp_select_all_active_players'
GO
CREATE PROCEDURE [dbo].[sp_select_all_active_players]
(
	@active		[bit]
)
AS
	BEGIN
		SELECT	[playerID], [givenName], [familyName], [yearDrafted], [active], [teamName], [espnID]
		FROM	[player]
		WHERE	@active = [active]
	END
GO

print '' print '*** creating sp_select_stats_by_active'
GO
CREATE PROCEDURE [dbo].[sp_select_stats_by_active]
(
	@active		[bit]
)
AS
	BEGIN
		SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount], [seasonID]
		FROM	[player] JOIN [playerStat]
				ON [player].[playerID] = [playerStat].[playerID]
				JOIN [stat] ON [stat].[statName] = [playerStat].[statName]
		WHERE	@active = [active]
	END
GO

print '' print '** creating sp_insert_new_player'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_player]
(
	@givenName		[nvarchar] (50),
	@familyName  	[nvarchar] (50),
	@yearDrafted 	[nvarchar] (4),
	@teamName		[nvarchar] (50)
)
AS
	BEGIN
		INSERT INTO [dbo].[player]
		([givenName], [familyName], [yearDrafted], [teamName])
		VALUES
		(@givenName, @familyName, @yearDrafted, @teamName)
		SELECT @@ROWCOUNT
	END
GO

print '' print '** creating sp_insert_new_player_stat'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_player_stat]
(
	@playerID	[int],
	@statName	[nvarchar] (50),
	@seasonID	[nvarchar] (9),
	@statAmount	[float]
)
AS
	BEGIN
		INSERT INTO [dbo].[playerStat]
		([playerID], [statName], [seasonID], [statAmount])
		VALUES
		(@playerID, @statName, @seasonID, @statAmount)
	END
GO

print '' print '*** Creating sp_players_by_team_name'
GO
CREATE PROCEDURE sp_players_by_team_name
	(
		@TeamName 		[nvarchar] (50)
	)
AS
	BEGIN
		SELECT	[playerID], [givenName], [familyName], [yearDrafted], [active], [teamName], [espnID]
		FROM	[player]
		WHERE	@TeamName = [TeamName]
	END
GO

print '' print '*** creating sp_select_stats_by_player_id'
GO
CREATE PROCEDURE [dbo].[sp_select_stats_by_player_id]
(
	@PlayerId		[int]
)
AS
	BEGIN
		SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount], [playerStat].[seasonID]
		FROM	[player] JOIN [playerStat]
				ON [player].[playerID] = [playerStat].[playerID]
				JOIN [stat] ON [stat].[statName] = [playerStat].[statName]
		WHERE	@PlayerId = [player].[playerID]
	END
GO

print '' print '*** creating sp_select_player_by_player_id'
GO
CREATE PROCEDURE [dbo].[sp_select_player_by_player_id]
(
	@PlayerId		[int]
)
AS
	BEGIN
		SELECT 	[playerID], [givenName], [familyName], [yearDrafted], [active], [teamName], [espnID]
		FROM 	[player]
		WHERE 	[playerID] = @PlayerId
	END
GO

print '' print '*** Creating sp_update_player_team_by_playerID'
GO
CREATE PROCEDURE [sp_update_player_team_by_playerID]
	(
		@PlayerID 		[int],
		
		@TeamName		[nvarchar] (50),
		@OldTeamName 	[nvarchar] (50)		
	)
AS
	BEGIN
		UPDATE 	[Player]
		SET		[teamName] = @TeamName
		WHERE	[PlayerID] = @PlayerID
		AND		[TeamName] = @OldTeamName
		
		RETURN @@ROWCOUNT
	END
GO	

print '' print '*** Creating sp_select_all_statNames'
GO
CREATE PROCEDURE [sp_select_all_statNames]
AS
	BEGIN
		SELECT	[statName]
		FROM	[Stat]
	END
GO

print '' print '*** Creating sp_select_all_seasonIDs'
GO
CREATE PROCEDURE [sp_select_all_seasonIDs]
AS
	BEGIN
		SELECT	[seasonID]
		FROM	[Season]
	END
GO

print '' print '*** Creating sp_select_stat_by_playerID_seasonID_and_statName'
GO
CREATE PROCEDURE [sp_select_stat_by_playerID_seasonID_and_statName]
	(
		@PlayerID	[int],
		@SeasonID	[nvarchar] (9),
		@statName	[nvarchar] (50)
	)
AS
	BEGIN
		SELECT	[playerID], [statName], [seasonID], [statAmount]
		FROM	[playerStat]
		WHERE	@PlayerID = [playerID]
		AND		@SeasonID = [seasonID]
		AND 	@StatName = [statName]
	END
GO

print '' print '*** Creating sp_update_stat_by_playerID_seasonID_and_statName'
GO
CREATE PROCEDURE [sp_update_stat_by_playerID_seasonID_and_statName]
	(
		@PlayerID		[int],
		
		@SeasonID		[nvarchar] (9),
		@StatName		[nvarchar] (50),
		@StatAmount		[float],
		
		@OldSeasonID	[nvarchar] (9),
		@OldStatName	[nvarchar] (50),
		@OldStatAmount	[float]
	)
AS
	BEGIN
		UPDATE 	[playerStat]
		SET		[statAmount] = @StatAmount
		WHERE	[PlayerID] = @PlayerID
		AND		[SeasonID] = @OldSeasonID
		AND		[StatName] = @OldStatName
		AND 	[StatAmount] = @OldStatAmount
		
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_select_schedule_by_season_and_week'
GO
CREATE PROCEDURE [sp_select_schedule_by_season_and_week]
	(
		@seasonID		[nvarchar] (9),
		@WeekNumber		[int]
	)
AS
	BEGIN
		SELECT	[gameID], [teamNameAway], [teamNameHome], [teamAwayScore], [teamHomeScore], [WeekNumber], [seasonID], [OverTime], [GameDate]
		FROM	[teamSchedule]
		WHERE	@seasonID = [SeasonID]
		AND		@WeekNumber = [WeekNumber]
	END
GO

print '' print '*** Creating sp_select_distinct_weeks'
GO
CREATE PROCEDURE [sp_select_distinct_weeks]
AS
	BEGIN
		SELECT	DISTINCT [WeekNumber]
		FROM	[teamSchedule]
	END
GO

print '' print '*** creating sp_select_stats_by_statName_AndOr_seasonID'
GO
CREATE PROCEDURE [dbo].[sp_select_stats_by_statName_AndOr_seasonID]
(
	@statName	[nvarchar] (50),
	@SeasonID	[nvarchar] (9)
)
AS
	BEGIN
		IF (@statName IS NOT NULL OR @statName = '') AND (@SeasonID IS NOT NULL OR @SeasonID = '')
			SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount], [seasonID]
			FROM	[player] JOIN [playerStat]
					ON [player].[playerID] = [playerStat].[playerID]
					JOIN [stat] ON [stat].[statName] = [playerStat].[statName]
			WHERE	@statName = [stat].[statName]
			AND		@seasonID = [seasonID]
		ELSE IF (@statName IS NOT NULL OR @statName = '') AND (@SeasonID IS NULL OR @SeasonID = '')
			SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount], [seasonID]
			FROM	[player] JOIN [playerStat]
					ON [player].[playerID] = [playerStat].[playerID]
					JOIN [stat] ON [stat].[statName] = [playerStat].[statName]
			WHERE	@statName = [stat].[statName]
		ELSE IF (@statName IS NULL OR @statName = '') AND (@SeasonID IS NOT NULL OR @SeasonID = '')
			SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount], [seasonID]
			FROM	[player] JOIN [playerStat]
					ON [player].[playerID] = [playerStat].[playerID]
					JOIN [stat] ON [stat].[statName] = [playerStat].[statName]
			WHERE	@seasonID = [seasonID]
		ELSE IF (@statName IS NULL OR @statName = '') AND (@SeasonID IS NULL OR @SeasonID = '')
			SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount], [seasonID]
			FROM	[player] JOIN [playerStat]
					ON [player].[playerID] = [playerStat].[playerID]
					JOIN [stat] ON [stat].[statName] = [playerStat].[statName]
	END
GO

print '' print '** creating sp_insert_new_game'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_game]
(
	@teamNameAway		[nvarchar] (50),
	@teamNameHome		[nvarchar] (50),
	@teamAwayScore		[int],
	@teamHomeScore		[int],
	@WeekNumber			[int],
	@seasonID			[nvarchar] (9),
	@OverTime			[bit],
	@GameDate			[datetime]
)
AS
	BEGIN
		INSERT INTO [dbo].[teamSchedule]
			([teamNameAway], [teamNameHome], [teamAwayScore], [teamHomeScore], [WeekNumber], [seasonID], [OverTime], [GameDate])
		VALUES
		(@teamNameAway, @teamNameHome, @teamAwayScore, @teamHomeScore, @WeekNumber, @seasonID, @OverTime, @GameDate)
	END
GO