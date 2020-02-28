/* *************************************************************** */
/*                SQL Server : Create Database Script              */
/*                                                                 */
/* Command Line Syntax:                                            */
/*     > sqlcmd.exe -U [user] -P [password] -I -i DataBase.sql     */
/*                                                                 */
/* *************************************************************** */

/* --------------------------------------------------------------- */
/* -------------------- Script Code ------------------------------ */
/* --------------------------------------------------------------- */


USE [master]
GO

--/****** Drop database if already exists  ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'MiniGig')
DROP DATABASE [MiniGig]
GO

USE [master]
GO
/* DataBase Creation */
                                  

CREATE DATABASE [MiniGig] ON  PRIMARY 
( NAME = 'MiniGig', FILENAME = 'C:\Temporary\MyProjects_IT\Database\MiniGig.mdf') 
LOG ON 
( NAME = 'MiniGig_log', FILENAME = 'C:\Temporary\MyProjects_IT\Database\MiniGig_log.ldf')
GO