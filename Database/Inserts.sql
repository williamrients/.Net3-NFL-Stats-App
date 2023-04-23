USE [Football_Stats_db]

print '' print '*** INSERTING TEST RECORDS'

/* User test records */
print '' print '*** inserting user test records'
GO
INSERT INTO [dbo].[users]
	([givenName], [familyName], [phone], [email])
	VALUES
		('William'	, 'Rients'		, '7148581433'		, 'william@company.com'),
		('Joanne'	, 'Smith'		, '13191231111'		, 'joanne@company.com'),
		('Martin'	, 'Jones'		, '13191232222'		, 'martin@company.com'),
		('Leo'		, 'Williams'	, '13191233333'		, 'leo@company.com')
GO

/* Role sample records */
print '' print '*** inserting sample role records'
GO
INSERT INTO [dbo].[role]
	([roleID], [description])
	VALUES
		('Administrator'	, 'administratiors user accounts and assigns roles'),
		('StatAdjuster'		, 'manages the stats of players'),
		('GeneralUser'		, 'views the players and teams only')
GO

print '' print '*** inserting sample userRole table'
GO
INSERT INTO [dbo].[userRole]
	([userID], [roleID])
	VALUES
		(100000		, 'Administrator'),
		(100001		, 'StatAdjuster'),
		(100002		, 'GeneralUser'),
		(100003		, 'GeneralUser')
GO

/* Team test records */
print '' print '*** inserting team test records'
GO
INSERT INTO [dbo].[team]
	([teamName], [teamMascot], [teamCity], [teamState], [teamAbbreviation])
	VALUES
	('Cardinals'	, 'Big Red'				, 'Glendale'			, 'Arizona'			, 'ARI'),
    ('Rams'			, 'Rampage'				, 'Los Angeles'			, 'California'		, 'LAR'),
    ('Chargers'		, 'Boltman'				, 'Los Angeles'			, 'California'		, 'LAC'),
    ('49ers'		, 'Sourdough Sam'		, 'San Francisco'		, 'California'		, 'SF'),
    ('Broncos'		, 'Thunder'				, 'Denver'				, 'Colorado'		, 'DEN'),
    ('Jaguars'		, 'Jaxson de Ville'		, 'Jacksonville '		, 'Florida'			, 'JAX'),
    ('Dolphins'		, 'T.D.'				, 'Miami'				, 'Florida'			, 'MIA'),
    ('Buccaneers'	, 'Captain Fear'		, 'Tampa Bay'			, 'Florida'			, 'TB'),
    ('Falcons'		, 'Freddie Falcon'		, 'Atlanta'				, 'Georgia'			, 'ATL'),
    ('Bears'		, 'Staley Da Bear'		, 'Chicago'				, 'Illinois'		, 'CHI'),
    ('Colts'		, 'Blue'				, 'Indianapolis'		, 'Indiana'			, 'IND'),
    ('Saints'		, 'Gumbo'				, 'New Orleans'			, 'Louisiana'		, 'NO'),
    ('Ravens'		, 'Poe'					, 'Baltimore'			, 'Maryland'		, 'BAL'),
    ('Commanders'	, 'Commander'			, 'Washington'			, 'Maryland'		, 'WAS'),
    ('Patriots'		, 'Pat Patriot'			, 'New England'			, 'Massachusetts'	, 'NE'),
    ('Lions'		, 'Roary'				, 'Detroit'				, 'Michigan'		, 'DET'),
    ('Vikings'		, 'Viktor the Viking'	, 'Minneapolis'			, 'Minnesota'		, 'MIN'),
    ('Chiefs'		, 'KC Wolf'				, 'Kansas City'			, 'Missouri'		, 'KC'),
    ('Raiders'		, 'Raider Rusher'		, 'Las Vegas'			, 'Nevada'			, 'LV'),
    ('Giants'		, 'Giant'				, 'New York'			, 'New Jersey'		, 'NYG'),
    ('Jets'			, 'Jet'					, 'New York'			, 'New Jersey'		, 'NYJ'),
    ('Bills'		, 'Billy Buffalo'		, 'Buffalo'				, 'New York'		, 'BUF'),
    ('Panthers'		, 'Sir Purr'			, 'Charlotte'			, 'North Carolina'	, 'CAR'),
    ('Bengals'		, 'Who Dey'				, 'Cincinnati'			, 'Ohio'			, 'CIN'),
    ('Browns'		, 'Swagger'				, 'Cincinnati'			, 'Ohio'			, 'CLE'),
	('Eagles'		, 'Swoop'				, 'Philadelphia'		, 'Pennsylvania'	, 'PHI'),
    ('Steelers'		, 'Steely McBeam'		, 'Pittsburgh'			, 'Pennsylvania'	, 'PIT'),
    ('Titans'		, 'T-Rac'				, 'Nashville'			, 'Tennessee'		, 'TEN'),
    ('Cowboys'		, 'Rowdy'				, 'Dallas'				, 'Texas'			, 'DAL'),
    ('Texans'		, 'Toro'				, 'Houston'				, 'Texas'			, 'HOU'),
    ('Seahawks'		, 'Blitz'				, 'Seattle'				, 'Washington'		, 'SEA'),
    ('Packers'		, 'Packer'				, 'Green Bay'			, 'Wisconsin'		, 'GB')
GO

/* Season test records */
print '' print '*** inserting season test records'
GO
INSERT INTO [dbo].[season]
	([seasonID])
	VALUES
	('2021-2022')
GO


/* Player sample records */
print '' print '*** inserting player test records'
GO
INSERT INTO [dbo].[player]
	([givenName], [familyName], [yearDrafted], [teamName], [espnID])
	VALUES
	('Kirk'			,'Cousins'			, '2012'	, 'Vikings'		, '14880'),
	('Patrick'		, 'Mahomes'			, '2017'	, 'Chiefs'		, '3139477'),
	('Tom'			, 'Brady'			, '2000'	, 'Buccaneers'	, '2330'),
	('Aaron'		, 'Rodgers'			, '2005'	, 'Packers'		, '8439'),
	('Russell'		, 'Wilson'			, '2012'	, 'Seahawks'	, '14881'),
	('Ben'			, 'Roethlisberger'	, '2004'	, 'Steelers'	, '5536'),
	('Josh'			, 'Allen'			, '2018'	, 'Bills'		, '3918298'),
	('Dak'			, 'Prescott'		, '2016'	, 'Cowboys'		, '2577417'),
	('Drew'			, 'Brees'			, '2001'	, 'Saints'		, '2580'),
	('Deshaun'		, 'Watson'			, '2017'	, 'Texans'		, '3122840'),
	('Matt'			, 'Ryan'			, '2008'	, 'Falcons'		, '11237'),
	('Baker'		, 'Mayfield'		, '2018'	, 'Browns'		, '3052587'),
	('Matthew'		, 'Stafford'		, '2009'	, 'Rams'		, '12483'),
	('Lamar'		, 'Jackson'			, '2018'	, 'Ravens'		, '3916387'),
	('Kyler'		, 'Murray'			, '2019'	, 'Cardinals'	, '3917315'),
	('Derek'		, 'Carr'			, '2014'	, 'Raiders'		, '16757'),
	('Justin'		, 'Herbert'			, '2020'	, 'Chargers'	, '4038941'),
	('Ryan'			, 'Tannehill'		, '2012'	, 'Titans'		, '14876'),
	('Jimmy'		, 'Garoppolo'		, '2014'	, '49ers'		, '16760'),
	('Tua'			, 'Tagovailoa'		, '2020'	, 'Dolphins'	, '4241479'),
	('Teddy'		, 'Bridgewater'		, '2014'	, 'Broncos'		, '16728'),
	('Jalen'		, 'Hurts'			, '2020'	, 'Eagles'		, '4040715'),
	('Cam'			, 'Newton'			, '2011'	, 'Patriots'	, '13994'),
	('Daniel'		, 'Jones'			, '2019'	, 'Giants'		, '3917792'),
	('Jared'		, 'Goff'			, '2016'	, 'Lions'		, '3046779'),
	('Sam'			, 'Darnold'			, '2018'	, 'Panthers'	, '3912547'),
	('Carson'		, 'Wentz'			, '2016'	, 'Colts'		, '2573079'),
	('Joe'			, 'Burrow'			, '2020'	, 'Bengals'		, '3915511'),
	
	('Derrick'		, 'Henry'			, '2016'	, 'Titans'		, '3043078'),
	('Alvin'		, 'Kamara'			, '2017'	, 'Saints'		, '3054850'),
	('Dalvin'		, 'Cook'			, '2017'	, 'Vikings'		, '3116593'),
	('Christian'	, 'McCaffrey'		, '2017'	, 'Panthers'	, '3117251'),
	('Nick'			, 'Chubb'			, '2018'	, 'Browns'		, '3128720'),
	('Aaron'		, 'Jones'			, '2017'	, 'Packers'		, '3042519'),
	('Ezekiel'		, 'Elliott'			, '2016'	, 'Cowboys'		, '3051392'),
	('Saquon'		, 'Barkley'			, '2018'	, 'Giants'		, '3929630'),
	('Chris'		, 'Carson'			, '2017'	, 'Seahawks'	, '3919596'),
	('Josh'			, 'Jacobs'			, '2019'	, 'Raiders'		, '3051716'),
	('David'		, 'Montgomery'		, '2019'	, 'Bears'		, '4035538'),
	('Miles'		, 'Sanders'			, '2019'	, 'Eagles'		, '4045163'),
	('Austin'		, 'Ekeler'			, '2017'	, 'Chargers'	, '3068267'),
	('James'		, 'Robinson'		, '2020'	, 'Jaguars'		, '4052042'),
	('Clyde'		, 'Edwards-Helaire'	, '2020'	, 'Chiefs'		, '4242214'),
	('Jonathan'		, 'Taylor'			, '2020'	, 'Colts'		, '4242335'),
	('Antonio'		, 'Gibson'			, '2020'	, 'Commanders'	, '4360294'),
	('Devin'		, 'Singletary'		, '2019'	, 'Bills'		, '4040761'),
	('Joe'			, 'Mixon'			, '2017'	, 'Bengals'		, '3116385'),
	('Melvin'		, 'Gordon'			, '2015'	, 'Broncos'		, '2576434'),
	
	('DeAndre'		, 'Hopkins' 		, '2013'	, 'Cardinals' 	, '15795'),
	('Michael' 		, 'Thomas' 			, '2016'	, 'Saints' 		, '2976316'),
	('Davante' 		, 'Adams' 			, '2014'	, 'Packers' 	, '16800'),
	('Tyreek' 		, 'Hill' 			, '2016'	, 'Chiefs' 		, '3116406'),
	('Julio' 		, 'Jones' 			, '2011'	, 'Falcons' 	, '13982'),
	('Stefon' 		, 'Diggs' 			, '2015'	, 'Bills' 		, '2976212'),
	('Keenan' 		, 'Allen' 			, '2013'	, 'Chargers' 	, '15818'),
	('Mike' 		, 'Evans' 			, '2014'	, 'Buccaneers' 	, '16737'),
	('Amari' 		, 'Cooper' 			, '2015'	, 'Cowboys' 	, '2976499'),
	('Odell' 		, 'Beckham Jr.' 	, '2014'	, 'Browns' 		, '16733'),
	('Adam' 		, 'Thielen' 		, '2013'	, 'Vikings' 	, '16460'),
	('Chris' 		, 'Godwin' 			, '2017'	, 'Buccaneers' 	, '3116165'),
	('D.K.' 		, 'Metcalf' 		, '2019'	, 'Seahawks' 	, '4047650'),
	('A.J.' 		, 'Brown' 			, '2019'	, 'Titans' 		, '4047646'),
	('Tyler' 		, 'Lockett' 		, '2015'	, 'Seahawks' 	, '2577327'),
	('Allen' 		, 'Robinson' 		, '2014'	, 'Bears' 		, '16799'),
	('Terry' 		, 'McLaurin' 		, '2019'	, 'Commanders' 	, '3121422'),
	('Cooper' 		, 'Kupp' 			, '2017'	, 'Rams' 		, '2977187'),
	('Calvin' 		, 'Ridley' 			, '2018'	, 'Falcons' 	, '3925357'),
	('Kenny' 		, 'Golladay' 		, '2017'	, 'Giants' 		, '2974858'),
	('JuJu' 		, 'Smith-Schuster'	, '2017'	, 'Steelers' 	, '3120348'),
	('Robert' 		, 'Woods' 			, '2013'	, 'Rams' 		, '15880'),
	('D.J.' 		, 'Moore' 			, '2018'	, 'Panthers' 	, '3915416'),
	('Tyler' 		, 'Boyd' 			, '2016'	, 'Bengals' 	, '3045144'),
	('CeeDee' 		, 'Lamb' 			, '2020'	, 'Cowboys' 	, '4241389'),
	('T.Y.' 		, 'Hilton' 			, '2012'	, 'Colts' 		, '14924')
GO

/* Position test records */
print '' print '*** inserting position test records'
GO
INSERT INTO [dbo].[position]
	([positionName], [positionDescription])
	VALUES
	('Quarterback'		, 'Player who starts the play'),
    ('Running back'		, 'Executes rushing plays'),
    ('Wide receiver'	, 'Pass-catching specialists')
GO

/* Stat test records */
print '' print '*** inserting stat test records'
GO
INSERT INTO [dbo].[stat]
	([statName], [statDescription])
	VALUES
	('Completion Percent'		, 'Percent of passes completed compared to incomplete'),
	('Touchdown Passes'			, 'Total touchdown passes thrown'),
	('Interceptions Thrown'		, 'Total interceptions throw'),

	('Rushing Yards'			, 'Total amount of yards ran with the ball'),
	('Rushing Touchdowns'		, 'Total touchdowns rushed'),
	('Receiving Yards'			, 'Total yards catching the ball'),
	('Receiving Touchdowns'		, 'Total touchdowns caught'),
	
	('Receptions'				, 'Total catches')
	
GO

-- /* Team Season test records */
-- print '' print '*** inserting teamSeason test records'
-- GO
-- INSERT INTO [dbo].[teamSeason]
	-- ([teamName], [seasonID], [playerID])
	-- VALUES
	-- ('Buccaneers', '2021-2022', 100000)
-- GO

/* Player Position test records */
print '' print '*** inserting playerPosition test records'
GO
INSERT INTO [dbo].[playerPosition]
	([playerID], [positionName])
	VALUES
	(100000		, 'Quarterback'),
	(100001		, 'Quarterback'),
	(100002		, 'Quarterback'),
	(100003		, 'Quarterback'),
	(100004		, 'Quarterback'),
	(100005		, 'Quarterback'),
	(100006		, 'Quarterback'),
	(100007		, 'Quarterback'),
	(100008		, 'Quarterback'),
	(100009		, 'Quarterback'),
	(100010		, 'Quarterback'),
	(100011		, 'Quarterback'),
	(100012		, 'Quarterback'),
	(100013		, 'Quarterback'),
	(100014		, 'Quarterback'),
	(100015		, 'Quarterback'),
	(100016		, 'Quarterback'),
	(100017		, 'Quarterback'),
	(100018		, 'Quarterback'),
	(100019		, 'Quarterback'),
	(100020		, 'Quarterback'),
	(100021		, 'Quarterback'),
	(100022		, 'Quarterback'),
	(100023		, 'Quarterback'),
	(100024		, 'Quarterback'),
	(100025		, 'Quarterback'),
	(100026		, 'Quarterback'),
	(100027		, 'Quarterback'),
	
	(100028		, 'Running back'),
	(100029		, 'Running back'),
	(100030		, 'Running back'),
	(100031		, 'Running back'),
	(100032		, 'Running back'),
	(100033		, 'Running back'),
	(100034		, 'Running back'),
	(100035		, 'Running back'),
	(100036		, 'Running back'),
	(100037		, 'Running back'),
	(100038		, 'Running back'),
	(100039		, 'Running back'),
	(100040		, 'Running back'),
	(100041		, 'Running back'),
	(100042		, 'Running back'),
	(100043		, 'Running back'),
	(100044		, 'Running back'),
	(100045		, 'Running back'),
	(100046		, 'Running back'),
	(100047		, 'Running back'),
	
	(100048		, 'Wide Receiver'),
	(100049		, 'Wide Receiver'),
	(100050		, 'Wide Receiver'),
	(100051		, 'Wide Receiver'),
	(100052		, 'Wide Receiver'),
	(100053		, 'Wide Receiver'),
	(100054		, 'Wide Receiver'),
	(100055		, 'Wide Receiver'),
	(100056		, 'Wide Receiver'),
	(100057		, 'Wide Receiver'),
	(100058		, 'Wide Receiver'),
	(100059		, 'Wide Receiver'),
	(100060		, 'Wide Receiver'),
	(100061		, 'Wide Receiver'),
	(100062		, 'Wide Receiver'),
	(100063		, 'Wide Receiver'),
	(100064		, 'Wide Receiver'),
	(100065		, 'Wide Receiver'),
	(100066		, 'Wide Receiver'),
	(100067		, 'Wide Receiver'),
	(100068		, 'Wide Receiver'),
	(100069		, 'Wide Receiver'),
	(100070		, 'Wide Receiver'),
	(100071		, 'Wide Receiver'),
	(100072		, 'Wide Receiver'),
	(100073		, 'Wide Receiver')
GO

/* Player Stat test records */
print '' print '*** inserting playerStat test records'
GO
INSERT INTO [dbo].[playerStat]
	([playerID], [statName], [seasonID], [statAmount])
	VALUES
	/* Quarterbacks */
	(100000		, 'Completion Percent'		, '2021-2022'	, 65.4),
	(100000		, 'Touchdown Passes'		, '2021-2022'	, 27),
	(100000		, 'Interceptions Thrown'	, '2021-2022'	, 12),
	
	(100001		, 'Completion Percent'		, '2021-2022'	, 11.4),
	(100001		, 'Touchdown Passes'		, '2021-2022'	, 21),
	(100001		, 'Interceptions Thrown'	, '2021-2022'	, 5),
	
	(100002		, 'Completion Percent'		, '2021-2022'	, 68.7),
	(100002		, 'Touchdown Passes'		, '2021-2022'	, 38),
	(100002		, 'Interceptions Thrown'	, '2021-2022'	, 6),
			
	(100003		, 'Completion Percent'		, '2021-2022'	, 69.1),
	(100003		, 'Touchdown Passes'		, '2021-2022'	, 40),
	(100003		, 'Interceptions Thrown'	, '2021-2022'	, 10),
				
	(100004		, 'Completion Percent'		, '2021-2022'	, 63.2),
	(100004		, 'Touchdown Passes'		, '2021-2022'	, 32),
	(100004		, 'Interceptions Thrown'	, '2021-2022'	, 11),
			
	(100005		, 'Completion Percent'		, '2021-2022'	, 66.5),
	(100005		, 'Touchdown Passes'		, '2021-2022'	, 35),
	(100005		, 'Interceptions Thrown'	, '2021-2022'	, 9),
			
	(100006		, 'Completion Percent'		, '2021-2022'	, 68.4),
	(100006		, 'Touchdown Passes'		, '2021-2022'	, 34),
	(100006		, 'Interceptions Thrown'	, '2021-2022'	, 7),
			
	(100007		, 'Completion Percent'		, '2021-2022'	, 64.8),
	(100007		, 'Touchdown Passes'		, '2021-2022'	, 29),
	(100007		, 'Interceptions Thrown'	, '2021-2022'	, 13),
			
	(100008		, 'Completion Percent'		, '2021-2022'	, 62.1),
	(100008		, 'Touchdown Passes'		, '2021-2022'	, 28),
	(100008		, 'Interceptions Thrown'	, '2021-2022'	, 14),
			
	(100009		, 'Completion Percent'		, '2021-2022'	, 67.5),
	(100009		, 'Touchdown Passes'		, '2021-2022'	, 33),
	(100009		, 'Interceptions Thrown'	, '2021-2022'	, 10),
			
	(100010		, 'Completion Percent'		, '2021-2022'	, 65.9),
	(100010		, 'Touchdown Passes'		, '2021-2022'	, 30),
	(100010		, 'Interceptions Thrown'	, '2021-2022'	, 11),
			
	(100011		, 'Completion Percent'		, '2021-2022'	, 69.6),
	(100011		, 'Touchdown Passes'		, '2021-2022'	, 38),
	(100011		, 'Interceptions Thrown'	, '2021-2022'	, 6),
			
	(100012		, 'Completion Percent'		, '2021-2022'	, 63.7),
	(100012		, 'Touchdown Passes'		, '2021-2022'	, 27),
	(100012		, 'Interceptions Thrown'	, '2021-2022'	, 12),
			
	(100013		, 'Completion Percent'		, '2021-2022'	, 64.5),
	(100013		, 'Touchdown Passes'		, '2021-2022'	, 31),
	(100013		, 'Interceptions Thrown'	, '2021-2022'	, 13),
			
	(100014		, 'Completion Percent'		, '2021-2022'	, 66.2),
	(100014		, 'Touchdown Passes'		, '2021-2022'	, 36),
	(100014		, 'Interceptions Thrown'	, '2021-2022'	, 9),
			
	(100015		, 'Completion Percent'		, '2021-2022'	, 67.8),
	(100015		, 'Touchdown Passes'		, '2021-2022'	, 35),
	(100015		, 'Interceptions Thrown'	, '2021-2022'	, 8),
				
	(100016		, 'Completion Percent'		, '2021-2022'	, 65.3),
	(100016		, 'Touchdown Passes'		, '2021-2022'	, 31),
	(100016		, 'Interceptions Thrown'	, '2021-2022'	, 10),
			
	(100017		, 'Completion Percent'		, '2021-2022'	, 63.9),
	(100017		, 'Touchdown Passes'		, '2021-2022'	, 29),
	(100017		, 'Interceptions Thrown'	, '2021-2022'	, 12),
			
	(100018		, 'Completion Percent'		, '2021-2022'	, 64.5),
	(100018		, 'Touchdown Passes'		, '2021-2022'	, 30),
	(100018		, 'Interceptions Thrown'	, '2021-2022'	, 11),
			
	(100019		, 'Completion Percent'		, '2021-2022'	, 68.2),
	(100019		, 'Touchdown Passes'		, '2021-2022'	, 34),
	(100019		, 'Interceptions Thrown'	, '2021-2022'	, 9),
			
	(100020		, 'Completion Percent'		, '2021-2022'	, 66.4),
	(100020		, 'Touchdown Passes'		, '2021-2022'	, 32),
	(100020		, 'Interceptions Thrown'	, '2021-2022'	, 10),
			
	(100021		, 'Completion Percent'		, '2021-2022'	, 67.7),
	(100021		, 'Touchdown Passes'		, '2021-2022'	, 33),
	(100021		, 'Interceptions Thrown'	, '2021-2022'	, 8),
			
	(100022		, 'Completion Percent'		, '2021-2022'	, 69.3),
	(100022		, 'Touchdown Passes'		, '2021-2022'	, 37),
	(100022		, 'Interceptions Thrown'	, '2021-2022'	, 7),
			
	(100023		, 'Completion Percent'		, '2021-2022'	, 62.8),
	(100023		, 'Touchdown Passes'		, '2021-2022'	, 27),
	(100023		, 'Interceptions Thrown'	, '2021-2022'	, 13),
			
	(100024		, 'Completion Percent'		, '2021-2022'	, 64.1),
	(100024		, 'Touchdown Passes'		, '2021-2022'	, 28),
	(100024		, 'Interceptions Thrown'	, '2021-2022'	, 12),
			
	(100025		, 'Completion Percent'		, '2021-2022'	, 66.9),
	(100025		, 'Touchdown Passes'		, '2021-2022'	, 34),
	(100025		, 'Interceptions Thrown'	, '2021-2022'	, 9),
			
	(100026		, 'Completion Percent'		, '2021-2022'	, 62.5),
	(100026		, 'Touchdown Passes'		, '2021-2022'	, 24),
	(100026		, 'Interceptions Thrown'	, '2021-2022'	, 14),
	
	(100027		, 'Completion Percent'		, '2021-2022'	, 55),
	(100027		, 'Touchdown Passes'		, '2021-2022'	, 32),
	(100027		, 'Interceptions Thrown'	, '2021-2022'	, 5),

	/* Running Backs */
	(100028		, 'Rushing Yards'			, '2021-2022'	, 1140),
	(100028		, 'Rushing Touchdowns'		, '2021-2022'	, 12),
	(100028		, 'Receiving Yards'			, '2021-2022'	, 350),
	(100028		, 'Receiving Touchdowns'	, '2021-2022'	, 3),

	(100029		, 'Rushing Yards'			, '2021-2022'	, 980),
	(100029		, 'Rushing Touchdowns'		, '2021-2022'	, 7),
	(100029		, 'Receiving Yards'			, '2021-2022'	, 330),
	(100029		, 'Receiving Touchdowns'	, '2021-2022'	, 1),

	(100030		, 'Rushing Yards'			, '2021-2022'	, 890),
	(100030		, 'Rushing Touchdowns'		, '2021-2022'	, 6),
	(100030		, 'Receiving Yards'			, '2021-2022'	, 280),
	(100030		, 'Receiving Touchdowns'	, '2021-2022'	, 2),
		
	(100031		, 'Rushing Yards'			, '2021-2022'	, 1200),
	(100031		, 'Rushing Touchdowns'		, '2021-2022'	, 11),
	(100031		, 'Receiving Yards'			, '2021-2022'	, 375),
	(100031		, 'Receiving Touchdowns'	, '2021-2022'	, 4),
		
	(100032		, 'Rushing Yards'			, '2021-2022'	, 975),
	(100032		, 'Rushing Touchdowns'		, '2021-2022'	, 10),
	(100032		, 'Receiving Yards'			, '2021-2022'	, 260),
	(100032		, 'Receiving Touchdowns'	, '2021-2022'	, 1),
		
	(100033		, 'Rushing Yards'			, '2021-2022'	, 1025),
	(100033		, 'Rushing Touchdowns'		, '2021-2022'	, 9),
	(100033		, 'Receiving Yards'			, '2021-2022'	, 290),
	(100033		, 'Receiving Touchdowns'	, '2021-2022'	, 3),
		
	(100034		, 'Rushing Yards'			, '2021-2022'	, 1100),
	(100034		, 'Rushing Touchdowns'		, '2021-2022'	, 8),
	(100034		, 'Receiving Yards'			, '2021-2022'	, 340),
	(100034		, 'Receiving Touchdowns'	, '2021-2022'	, 2),
	
	(100035		, 'Rushing Yards'			, '2021-2022'	, 950),
	(100035		, 'Rushing Touchdowns'		, '2021-2022'	, 7),
	(100035		, 'Receiving Yards'			, '2021-2022'	, 315),
	(100035		, 'Receiving Touchdowns'	, '2021-2022'	, 2),
			
	(100036		, 'Rushing Yards'			, '2021-2022'	, 1035),
	(100036		, 'Rushing Touchdowns'		, '2021-2022'	, 9),
	(100036		, 'Receiving Yards'			, '2021-2022'	, 280),
	(100036		, 'Receiving Touchdowns'	, '2021-2022'	, 1),
			
	(100037		, 'Rushing Yards'			, '2021-2022'	, 1150),
	(100037		, 'Rushing Touchdowns'		, '2021-2022'	, 11),
	(100037		, 'Receiving Yards'			, '2021-2022'	, 370),
	(100037		, 'Receiving Touchdowns'	, '2021-2022'	, 3),
			
	(100038		, 'Rushing Yards'			, '2021-2022'	, 920),
	(100038		, 'Rushing Touchdowns'		, '2021-2022'	, 6),
	(100038		, 'Receiving Yards'			, '2021-2022'	, 265),
	(100038		, 'Receiving Touchdowns'	, '2021-2022'	, 1),
			
	(100039		, 'Rushing Yards'			, '2021-2022'	, 1080),
	(100039		, 'Rushing Touchdowns'		, '2021-2022'	, 10),
	(100039		, 'Receiving Yards'			, '2021-2022'	, 355),
	(100039		, 'Receiving Touchdowns'	, '2021-2022'	, 4),
			
	(100040		, 'Rushing Yards'			, '2021-2022'	, 875),
	(100040		, 'Rushing Touchdowns'		, '2021-2022'	, 5),
	(100040		, 'Receiving Yards'			, '2021-2022'	, 240),
	(100040		, 'Receiving Touchdowns'	, '2021-2022'	, 2),
			
	(100041		, 'Rushing Yards'			, '2021-2022'	, 1130),
	(100041		, 'Rushing Touchdowns'		, '2021-2022'	, 12),
	(100041		, 'Receiving Yards'			, '2021-2022'	, 325),
	(100041		, 'Receiving Touchdowns'	, '2021-2022'	, 3),
			
	(100042		, 'Rushing Yards'			, '2021-2022'	, 950),
	(100042		, 'Rushing Touchdowns'		, '2021-2022'	, 8),
	(100042		, 'Receiving Yards'			, '2021-2022'	, 300),
	(100042		, 'Receiving Touchdowns'	, '2021-2022'	, 2),
	
	(100043		, 'Rushing Yards'			, '2021-2022'	, 1040),
	(100043		, 'Rushing Touchdowns'		, '2021-2022'	, 9),
	(100043		, 'Receiving Yards'			, '2021-2022'	, 320),
	(100043		, 'Receiving Touchdowns'	, '2021-2022'	, 3),
			
	(100044		, 'Rushing Yards'			, '2021-2022'	, 1120),
	(100044		, 'Rushing Touchdowns'		, '2021-2022'	, 11),
	(100044		, 'Receiving Yards'			, '2021-2022'	, 335),
	(100044		, 'Receiving Touchdowns'	, '2021-2022'	, 4),
			
	(100045		, 'Rushing Yards'			, '2021-2022'	, 930),
	(100045		, 'Rushing Touchdowns'		, '2021-2022'	, 7),
	(100045		, 'Receiving Yards'			, '2021-2022'	, 290),
	(100045		, 'Receiving Touchdowns'	, '2021-2022'	, 1),
			
	(100046		, 'Rushing Yards'			, '2021-2022'	, 1090),
	(100046		, 'Rushing Touchdowns'		, '2021-2022'	, 10),
	(100046		, 'Receiving Yards'			, '2021-2022'	, 345),
	(100046		, 'Receiving Touchdowns'	, '2021-2022'	, 2),
	
	(100047		, 'Rushing Yards'			, '2021-2022'	, 1231),
	(100047		, 'Rushing Touchdowns'		, '2021-2022'	, 6),
	(100047		, 'Receiving Yards'			, '2021-2022'	, 123),
	(100047		, 'Receiving Touchdowns'	, '2021-2022'	, 55),
	
	/* Wide Receivers */
	(100048		, 'Receptions'				, '2021-2022'	, 62),
	(100048		, 'Receiving Yards'			, '2021-2022'	, 810),
	(100048		, 'Receiving Touchdowns'	, '2021-2022'	, 6),
			
	(100049		, 'Receptions'				, '2021-2022'	, 75),
	(100049		, 'Receiving Yards'			, '2021-2022'	, 980),
	(100049		, 'Receiving Touchdowns'	, '2021-2022'	, 8),
			
	(100050		, 'Receptions'				, '2021-2022'	, 55),
	(100050		, 'Receiving Yards'			, '2021-2022'	, 710),
	(100050		, 'Receiving Touchdowns'	, '2021-2022'	, 5),
			
	(100051		, 'Receptions'				, '2021-2022'	, 80),
	(100051		, 'Receiving Yards'			, '2021-2022'	, 1070),
	(100051		, 'Receiving Touchdowns'	, '2021-2022'	, 9),
			
	(100052		, 'Receptions'				, '2021-2022'	, 65),
	(100052		, 'Receiving Yards'			, '2021-2022'	, 840),
	(100052		, 'Receiving Touchdowns'	, '2021-2022'	, 7),
			
	(100053		, 'Receptions'				, '2021-2022'	, 70),
	(100053		, 'Receiving Yards'			, '2021-2022'	, 930),
	(100053		, 'Receiving Touchdowns'	, '2021-2022'	, 6),
			
	(100054		, 'Receptions'				, '2021-2022'	, 60),
	(100054		, 'Receiving Yards'			, '2021-2022'	, 800),
	(100054		, 'Receiving Touchdowns'	, '2021-2022'	, 4),
			
	(100055		, 'Receptions'				, '2021-2022'	, 85),
	(100055		, 'Receiving Yards'			, '2021-2022'	, 1100),
	(100055		, 'Receiving Touchdowns'	, '2021-2022'	, 10),
			
	(100056		, 'Receptions'				, '2021-2022'	, 58),
	(100056		, 'Receiving Yards'			, '2021-2022'	, 780),
	(100056		, 'Receiving Touchdowns'	, '2021-2022'	, 5),
			
	(100057		, 'Receptions'				, '2021-2022'	, 72),
	(100057		, 'Receiving Yards'			, '2021-2022'	, 960),
	(100057		, 'Receiving Touchdowns'	, '2021-2022'	, 7),
			
	(100058		, 'Receptions'				, '2021-2022'	, 77),
	(100058		, 'Receiving Yards'			, '2021-2022'	, 1010),
	(100058		, 'Receiving Touchdowns'	, '2021-2022'	, 8),
			
	(100059		, 'Receptions'				, '2021-2022'	, 54),
	(100059		, 'Receiving Yards'			, '2021-2022'	, 690),
	(100059		, 'Receiving Touchdowns'	, '2021-2022'	, 4),
    
	(100060		, 'Receptions'				, '2021-2022'	, 61),
	(100060		, 'Receiving Yards'			, '2021-2022'	, 830),
	(100060		, 'Receiving Touchdowns'	, '2021-2022'	, 5),
			
	(100061		, 'Receptions'				, '2021-2022'	, 68),
	(100061		, 'Receiving Yards'			, '2021-2022'	, 910),
	(100061		, 'Receiving Touchdowns'	, '2021-2022'	, 6),
			
	(100062		, 'Receptions'				, '2021-2022'	, 74),
	(100062		, 'Receiving Yards'			, '2021-2022'	, 1000),
	(100062		, 'Receiving Touchdowns'	, '2021-2022'	, 7),
			
	(100063		, 'Receptions'				, '2021-2022'	, 57),
	(100063		, 'Receiving Yards'			, '2021-2022'	, 760),
	(100063		, 'Receiving Touchdowns'	, '2021-2022'	, 4),
			
	(100064		, 'Receptions'				, '2021-2022'	, 63),
	(100064		, 'Receiving Yards'			, '2021-2022'	, 820),
	(100064		, 'Receiving Touchdowns'	, '2021-2022'	, 5),
			
	(100065		, 'Receptions'				, '2021-2022'	, 71),
	(100065		, 'Receiving Yards'			, '2021-2022'	, 940),
	(100065		, 'Receiving Touchdowns'	, '2021-2022'	, 6),
			
	(100066		, 'Receptions'				, '2021-2022'	, 66),
	(100066		, 'Receiving Yards'			, '2021-2022'	, 890),
	(100066		, 'Receiving Touchdowns'	, '2021-2022'	, 7),
			
	(100067		, 'Receptions'				, '2021-2022'	, 55),
	(100067		, 'Receiving Yards'			, '2021-2022'	, 720),
	(100067		, 'Receiving Touchdowns'	, '2021-2022'	, 4),
			
	(100068		, 'Receptions'				, '2021-2022'	, 79),
	(100068		, 'Receiving Yards'			, '2021-2022'	, 1050),
	(100068		, 'Receiving Touchdowns'	, '2021-2022'	, 9),
			
	(100069		, 'Receptions'				, '2021-2022'	, 50),
	(100069		, 'Receiving Yards'			, '2021-2022'	, 680),
	(100069		, 'Receiving Touchdowns'	, '2021-2022'	, 3),
			
	(100070		, 'Receptions'				, '2021-2022'	, 73),
	(100070		, 'Receiving Yards'			, '2021-2022'	, 990),
	(100070		, 'Receiving Touchdowns'	, '2021-2022'	, 8),
			
	(100071		, 'Receptions'				, '2021-2022'	, 59),
	(100071		, 'Receiving Yards'			, '2021-2022'	, 790),
	(100071		, 'Receiving Touchdowns'	, '2021-2022'	, 5),
	
	(100072		, 'Receptions'				, '2021-2022'	, 64),
	(100072		, 'Receiving Yards'			, '2021-2022'	, 840),
	(100072		, 'Receiving Touchdowns'	, '2021-2022'	, 6),
			
	(100073		, 'Receptions'				, '2021-2022'	, 69),
	(100073		, 'Receiving Yards'			, '2021-2022'	, 920),
	(100073		, 'Receiving Touchdowns'	, '2021-2022'	, 7)
GO