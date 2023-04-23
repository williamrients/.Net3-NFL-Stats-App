USE [Football_Stats_db]

print '' print '*** CREATING STORED PROCEDURES'

/* User Related */

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

/* Select Users by Active*/
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

/* Insert New User and Role*/
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

/* Insert New User */
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

/* Select All Roles*/
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

/* Team Related */

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

/* Player Related */

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
		SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount]
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
	@givenName	 [nvarchar] (50),
	@familyName  [nvarchar] (50),
	@yearDrafted [nvarchar] (4)
)
AS
	BEGIN
		INSERT INTO [dbo].[player]
		([givenName], [familyName], [yearDrafted])
		VALUES
		(@givenName, @familyName, @yearDrafted)
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
		SELECT	[player].[playerID], [givenName], [familyName], [active], [playerStat].[statName], [statAmount]
		FROM	[player] JOIN [playerStat]
				ON [player].[playerID] = [playerStat].[playerID]
				JOIN [stat] ON [stat].[statName] = [playerStat].[statName]
		WHERE	@PlayerId = [player].[playerID]
	END
GO