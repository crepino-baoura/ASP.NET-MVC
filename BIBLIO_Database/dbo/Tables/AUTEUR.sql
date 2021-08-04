CREATE TABLE [dbo].[AUTEUR] (
    [auteur_id] INT           IDENTITY (1, 1) NOT NULL,
    [nom]       VARCHAR (255) NULL,
    [prenom]    VARCHAR (255) NULL,
    [tel]       VARCHAR (255) NULL,
    [pays]      VARCHAR (255) NULL,
    [adresse]   VARCHAR (255) NULL,
    CONSTRAINT [PK_AUTEUR] PRIMARY KEY CLUSTERED ([auteur_id] ASC)
);

