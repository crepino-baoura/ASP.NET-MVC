CREATE TABLE [dbo].[LIVRE] (
    [livre_id]             INT           IDENTITY (1, 1) NOT NULL,
    [libelle]              VARCHAR (255) NULL,
    [url]                  VARCHAR (255) NULL,
    [image_livre]          VARCHAR (255) NULL,
    [date_edit]            DATETIME      NULL,
    [genre_id]             INT           NULL,
    [commentlitteraire_id] INT           NULL,
    [AUTEUR]               INT           NULL,
    [editeur_id]           INT           NULL,
    PRIMARY KEY CLUSTERED ([livre_id] ASC),
    FOREIGN KEY ([AUTEUR]) REFERENCES [dbo].[AUTEUR] ([auteur_id]),
    FOREIGN KEY ([commentlitteraire_id]) REFERENCES [dbo].[COURANTLITTERAIRE] ([commentlitteraire_id]),
    FOREIGN KEY ([editeur_id]) REFERENCES [dbo].[EDITEUR] ([editeur_id]),
    FOREIGN KEY ([genre_id]) REFERENCES [dbo].[GENRE] ([genre_id])
);

