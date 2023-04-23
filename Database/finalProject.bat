ECHO off

sqlcmd -S localhost -E -i NFLStatsCreate.sql

sqlcmd -S localhost -E -i Inserts.sql

sqlcmd -S localhost -E -i storedProcedures.sql

rem server is localhost

ECHO .
ECHO if no errors appear DB was created
PAUSE