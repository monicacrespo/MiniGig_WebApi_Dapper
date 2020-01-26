/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

PRINT('Post-Deployment Script');

/***** SEED DATA FOR MUSIC GENRES TABLE *****/

INSERT INTO [dbo].[MusicGenres]([Category]) VALUES ('Pop');
INSERT INTO [dbo].[MusicGenres]([Category]) VALUES ('Rock');
INSERT INTO [dbo].[MusicGenres]([Category]) VALUES ('Punk');
INSERT INTO [dbo].[MusicGenres]([Category]) VALUES ('Jazz');
INSERT INTO [dbo].[MusicGenres]([Category]) VALUES ('Reggaeton');
INSERT INTO [dbo].[MusicGenres]([Category]) VALUES ('Folk');
INSERT INTO [dbo].[MusicGenres]([Category]) VALUES ('Flamenco');

/***** SEED DATA FOR CONTACTS TABLE *****/
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('David Bowie','2020-06-10',2);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Bruce Springsteen','2020-06-10',2);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Muse','2020-07-10',2);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Chacer Live Gig','2020-06-15',3);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Ed Sheeran Pop','2020-06-15',1);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Luis Fonsi & Daddy Yankee','2020-06-16',5);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Alejando Sanz','2020-06-16',1);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Adele Concert','2020-06-28',1);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Shakira Concert','2020-06-28',1);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Amy Winehouse','2020-06-28',1);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Lady Gaga','2020-06-28',1);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Sunday Jazz Lunch','2020-06-28',4);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('New York Brass Band','2020-06-28',4);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('The Chicago Blues Brothers','2020-08-28',4);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Ballet Flamenco Sara Baras','2020-08-28',7);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Jesus Carmona','2020-07-13',7);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Miguel Poveda','2020-07-8',7);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Jesús Carmona with Ries, Erza and Dorante','2020-07-8',7);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Amir ElSaffar Ensemble','2020-07-8',7);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Bob Dylan','2020-04-01',6);
INSERT INTO [dbo].[Gigs]([Name],[GigDate],[MusicGenreId]) VALUES ('Lewis Capaldi - Someone You Loved','2020-04-01',6);
