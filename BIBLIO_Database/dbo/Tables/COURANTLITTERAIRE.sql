CREATE TABLE [dbo].[COURANTLITTERAIRE] (
    [commentlitteraire_id] INT           IDENTITY (1, 1) NOT NULL,
    [libelle]              VARCHAR (255) NULL,
    [genre_id]             INT           NULL,
    PRIMARY KEY CLUSTERED ([commentlitteraire_id] ASC),
    FOREIGN KEY ([genre_id]) REFERENCES [dbo].[GENRE] ([genre_id])
);

