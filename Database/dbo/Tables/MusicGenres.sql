CREATE TABLE [dbo].[MusicGenres] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Category] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.MusicGenres] PRIMARY KEY CLUSTERED ([Id] ASC)
);

