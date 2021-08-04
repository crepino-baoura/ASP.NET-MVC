/*create database BD_GESTION_BIBLIO;*/
use BD_GESTION_BIBLIO;

CREATE TABLE EDITEUR(
	editeur_id int IDENTITY(1,1) NOT NULL,
	libelle varchar(255) not NULL,
	adresse varchar(255) NULL,
	tel varchar(255) not NULL,
	pays varchar(255) not NULL,
CONSTRAINT PK_EDITEUR PRIMARY KEY (editeur_id)
	)


	CREATE TABLE AUTEUR(
	auteur_id int IDENTITY(1,1) NOT NULL,
	nom varchar(255) not NULL,
	prenom varchar(255) not NULL,
	tel varchar(255) not NULL,
	pays varchar(255) not NULL,
	adresse varchar(255) NULL,
CONSTRAINT PK_AUTEUR PRIMARY KEY (auteur_id)
	)

	CREATE TABLE GENRE(
	genre_id int IDENTITY(1,1) NOT NULL,
	libelle varchar(255) not NULL,
CONSTRAINT PK_GENRE PRIMARY KEY (genre_id)
	)

		CREATE TABLE COURANTLITTERAIRE(
	commentlitteraire_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	libelle varchar(255) not NULL,
	genre_id int FOREIGN KEY REFERENCES GENRE(genre_id)
	)

	CREATE TABLE LIVRE(
	livre_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	libelle varchar(255) not NULL,
	url varchar(255) NULL,
	date_edit datetime,
	genre_id int FOREIGN KEY REFERENCES GENRE(genre_id),
	commentlitteraire_id int FOREIGN KEY REFERENCES COURANTLITTERAIRE(commentlitteraire_id),
	AUTEUR int FOREIGN KEY REFERENCES AUTEUR(auteur_id),
	editeur_id int FOREIGN KEY REFERENCES EDITEUR(editeur_id)
	)
