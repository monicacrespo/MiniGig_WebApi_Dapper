CREATE TABLE [dbo].[Gigs] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [GigDate]      DATETIME       NOT NULL,
    [MusicGenreId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Gigs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Gigs_dbo.MusicGenres_MusicGenreId] FOREIGN KEY ([MusicGenreId]) REFERENCES [dbo].[MusicGenres] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_GigIndexByDate]
    ON [dbo].[Gigs]([Id] ASC, [GigDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_GigIndexByMusicGenreId]
    ON [dbo].[Gigs]([MusicGenreId] ASC);

