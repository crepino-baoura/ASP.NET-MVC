CREATE TABLE [dbo].[EDITEUR] (
    [editeur_id] INT           IDENTITY (1, 1) NOT NULL,
    [libelle]    VARCHAR (255) NULL,
    [adresse]    VARCHAR (255) NULL,
    [tel]        VARCHAR (255) NULL,
    [pays]       VARCHAR (255) NULL,
    CONSTRAINT [PK_EDITEUR] PRIMARY KEY CLUSTERED ([editeur_id] ASC)
);

