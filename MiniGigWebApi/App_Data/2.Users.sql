
/* *************************************************************** */
/*                SQL Server : Create Users Script                 */
/* 																   */
/* Command Line Syntax:						                       */
/*       > sqlcmd.exe -U [user] -P [password] -I -i Users.sql      */
/* 														  		   */
/* *************************************************************** */


/* --------------------------------------------------------------- */
/* -------------------- Script Code ------------------------------ */
/* --------------------------------------------------------------- */

/**** Delete User if already exists ******/

IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = 'userminigig')
DROP LOGIN [userminigig]
GO

/******   Create LoginUser    ******/

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'userminigig')
CREATE LOGIN [userminigig] 
WITH   PASSWORD='password', 
	   DEFAULT_DATABASE=[MiniGig], 
	   CHECK_EXPIRATION=OFF, 
	   CHECK_POLICY=OFF
GO

USE minigig
GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'userminigig')
DROP USER [userminigig]
GO

CREATE USER [userminigig] FOR LOGIN [userminigig] WITH DEFAULT_SCHEMA=[dbo]
GO

exec sp_addrolemember N'db_datareader', N'userminigig' 
GO
exec sp_addrolemember N'db_datawriter', N'userminigig'
GO

GRANT EXECUTE ON SCHEMA::[dbo] TO [userminigig];

--In production environment the role is restricted to read and write, but not owner
/******   Set user as database dbo  ******/
--SP_CHANGEDBOWNER 'userminigig'
--GO