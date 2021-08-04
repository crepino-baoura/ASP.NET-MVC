CREATE TABLE [dbo].[GENRE] (
    [genre_id] INT           IDENTITY (1, 1) NOT NULL,
    [libelle]  VARCHAR (255) NULL,
    CONSTRAINT [PK_GENRE] PRIMARY KEY CLUSTERED ([genre_id] ASC)
);

