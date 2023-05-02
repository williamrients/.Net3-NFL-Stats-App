/* check whether the database exists, if so, drop it */
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'Football_Stats_db')
BEGIN
	DROP DATABASE Football_Stats_db
	print '' print '*** dropping database Football_Stats_db'
END
GO

print '' print '*** creating database Football_Stats_db'
GO
CREATE DATABASE Football_Stats_db
GO

print '' print '*** using Football_Stats_db'
GO
USE [Football_Stats_db]
GO

/* User table */
print '' print '*** creating user table'
GO
CREATE TABLE [dbo].[users] (
	[userID]		[int] IDENTITY(100000,1)	NOT NULL,
	[givenName]		[nvarchar](50)				NOT NULL,
	[familyName]	[nvarchar](100)				NOT NULL,
	[phone]			[nvarchar](13)				NOT NULL,
	[email]			[nvarchar](100)				NOT NULL,
	[PasswordHash]	[nvarchar](100)				NOT NULL DEFAULT
		'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Active]		[bit]						NOT NULL DEFAULT 1,
	CONSTRAINT [pk_userID] PRIMARY KEY([userID]),
	CONSTRAINT [ak_email] UNIQUE([email])
)
GO

/* Role table */
print '' print '*** createing Role table'
GO
CREATE TABLE [dbo].[role] (
	[roleID]		[nvarchar](50)				NOT NULL,
	[description]	[nvarchar](250)				NULL,
	CONSTRAINT [pk_roleID] PRIMARY KEY ([roleID])
)
GO

/* UserRole join table to join User and Roles */
print '' print '*** creating UserRole table'
GO
CREATE TABLE [dbo].[userRole] (
	[userID]	[int]						NOT NULL,
	[roleID]	[nvarchar](50)				NOT NULL,
	CONSTRAINT [fk_userRole_userID]		FOREIGN KEY ([userID])
		REFERENCES [dbo].[users] ([userID]),
	CONSTRAINT [fk_userRole_roleID]		FOREIGN KEY ([roleID])
		REFERENCES [dbo].[role] ([roleID]),
	CONSTRAINT [pk_userRole] PRIMARY KEY ([userID], [roleID])
)
GO

/* Team table */
print '' print '*** creating team table'
GO
CREATE TABLE [dbo].[team] (
	[teamName]			[nvarchar] (50)				NOT NULL,
	[teamMascot]		[nvarchar] (50)				NOT NULL,
	[teamCity]			[nvarchar] (50)				NOT NULL,
	[teamState]			[nvarchar] (50)				NOT NULL,
	[teamAbbreviation]	[nvarchar] (3)				NOT NULL,
	[active]			[bit]						NOT NULL DEFAULT 1,	
	CONSTRAINT [pk_teamName] PRIMARY KEY([teamName])
)
GO

/* Season table */
print '' print '*** creating season table'
GO
CREATE TABLE [dbo].[season] (
	[seasonID]		[nvarchar] (9)			NOT NULL,
	CONSTRAINT [pk_seasonID] PRIMARY KEY([seasonID])
)
GO

/* Player table */
print '' print '*** creating player table'
GO
CREATE TABLE [dbo].[player] (
	[playerID]			[int] IDENTITY(100000,1)	NOT NULL,
	[givenName]			[nvarchar] (50)				NOT NULL,
	[familyName]		[nvarchar] (50)				NOT NULL,
	[yearDrafted]		[nvarchar] (4)				NOT NULL,
	[active]			[bit]						NOT NULL DEFAULT 1,
	[teamName]			[nvarchar] (50)				NOT NULL,
	[espnID]			[nvarchar] (10)				NULL,
	CONSTRAINT [pk_playerID] PRIMARY KEY([playerID]),
	CONSTRAINT [fk_teamName] FOREIGN KEY ([TeamName])
	REFERENCES [dbo].[team] ([teamName])
)
GO

/* Position table */
print '' print '*** creating position table'
GO
CREATE TABLE [dbo].[position] (
	[positionName]				[nvarchar] (50) 		NOT NULL,
	[positionDescription]		[nvarchar] (255)		NOT NULL,
	CONSTRAINT [pk_positionName] PRIMARY KEY([positionName])
)
GO

/* Stat table */
print '' print '*** creating stat table'
GO
CREATE TABLE [dbo].[stat] (
	[statName]				[nvarchar] (50) 		NOT NULL,
	[statDescription]		[nvarchar] (255)		NOT NULL,
	CONSTRAINT [pk_statName] PRIMARY KEY([statName])
)
GO

/* Team Season table */
 print '' print '*** creating teamSchedule table'
 GO
 CREATE TABLE [dbo].[teamSchedule] (
	[gameID]			[int] IDENTITY(100000,1)	NOT NULL,
	[teamNameAway]		[nvarchar]	(50)			NOT NULL,
	[teamNameHome]		[nvarchar]	(50)			NOT NULL,
	[teamAwayScore]		[int]						NULL,
	[teamHomeScore]		[int]						NULL,
	[WeekNumber]		[int]						NOT NULL,
	[seasonID]			[nvarchar] (9)				NOT NULL,	
	[OverTime]			[bit]						NULL,	
	[GameDate]			[datetime]					NOT NULL,
	CONSTRAINT [pk_gameID] PRIMARY KEY([gameID]),
	CONSTRAINT [fk_teamSchedule_teamNameAway]	FOREIGN KEY ([teamNameAway])
		REFERENCES [dbo].[team] ([teamName]),
	CONSTRAINT [fk_teamSchedule_teamNameHome]	FOREIGN KEY ([teamNameHome])
		REFERENCES [dbo].[team] ([teamName]),
	CONSTRAINT [fk_teamSchedule_seasonID]	FOREIGN KEY ([seasonID])
		REFERENCES [dbo].[season] ([seasonID])
	)
	GO

/* Player Position table */
print '' print '*** creating playerPosition table'
GO
CREATE TABLE [dbo].[playerPosition] (
	[playerID]			[int]					NOT NULL,
	[positionName]		[nvarchar] (50) 		NOT NULL,
	CONSTRAINT [fk_playerPosition_playerID]		FOREIGN KEY ([playerID])
		REFERENCES [dbo].[player] ([playerID]),
	CONSTRAINT [fk_playerPosition_positionName]		FOREIGN KEY ([positionName])
		REFERENCES [dbo].[position] ([positionName]),
	CONSTRAINT [pk_playerPosition] PRIMARY KEY ([playerID], [positionName])
)
GO

/* Player Stat table */
print '' print '*** creating playerStat table'
GO
CREATE TABLE [dbo].[playerStat] (
	[playerID]			int						NOT NULL,
	[statName]			[nvarchar] (50)			NOT NULL,
	[seasonID]			[nvarchar] (9)			NOT NULL,
	[statAmount]		[float]					NOT NULL,
	CONSTRAINT [fk_playerStat_playerID]		FOREIGN KEY ([playerID])
		REFERENCES [dbo].[player] ([playerID]),
	CONSTRAINT [fk_playerStat_statName]		FOREIGN KEY ([statName])
		REFERENCES [dbo].[stat] ([statName]),
	CONSTRAINT [fk_playerStat_seasonID]		FOREIGN KEY ([seasonID])
		REFERENCES [dbo].[season] (seasonID),
	CONSTRAINT [pk_playerStat] PRIMARY KEY ([playerID], [statName], [seasonID])
)
GO