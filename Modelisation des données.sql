-- Question 1.
CREATE DATABASE GestionVoyage;
GO

USE [GestionVoyage]
CREATE TABLE Arrivees(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[NomNavire] nvarchar(max) NOT NULL,
	[DateHeureArrivee] DATETIME NOT NULL,
	[PortOrigine] nvarchar(max) NOT NULL,
	[Terminal] INT NOT NULL)
GO

CREATE TABLE Departs(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[NomNavire] nvarchar(max) NOT NULL,
	[DateHeureDepart] DATETIME NOT NULL,
	[PortDestination] nvarchar(max) NOT NULL,
	[Quai] INT NOT NULL)
GO

-- Question 2.
---- 1.
DECLARE @moisEnCours int = MONTH(GETDATE()),
		@anneeEnCours int = YEAR(GETDATE())

SELECT * FROM Departs 
WHERE MONTH(DateHeureDepart) = @moisEnCours 
	  AND YEAR(DateHeureDepart) = @anneeEnCours

---- 2.
SELECT COUNT(*) FROM Arrivees
WHERE PortOrigine = 'New York'

---- 3.
SELECT TOP 1 NomNavire FROM Arrivees
ORDER BY DateHeureArrivee DESC

---- 4.
SELECT * FROM Departs
WHERE Quai = 72 
	  AND YEAR(DateHeureDepart) = 2024

---- Question 3
ALTER TABLE Arrivees ADD TypeCargaison nvarchar(max) NOT NULL DEFAULT 'Inconnu'
ALTER TABLE Departs ADD TypeCargaison nvarchar(max) NOT NULL DEFAULT 'Inconnu'

-- Question 4.
-- =============================================
-- Author:		Maxime Aubin-Forest
-- Create date: 2024-05-16
-- Description:	Le Port de Montr�al souhaite automatiser la g�n�ration d�un rapport mensuel sur les voyages effectu�s par les diff�rents navires.
-- EXEC GenererRapportMensuel @mois = 5, @annee = 2024
-- =============================================
CREATE OR ALTER PROCEDURE GenererRapportMensuel
	-- Add the parameters for the stored procedure here
	@mois int,
	@annee int
AS
BEGIN
	SELECT 'Arriv�e'		AS 'Voyage',
		   NomNavire		AS 'Nom du navire',
		   FORMAT(DateHeureArrivee, 'dd-MM-yyyy hh:mm')	AS 'Date et heure du voyage',
		   PortOrigine		AS 'Port',
		   TypeCargaison	AS 'Type de cargaison'
	FROM Arrivees 
	WHERE MONTH(DateHeureArrivee) = @mois 
	  AND YEAR(DateHeureArrivee) = @annee

	UNION

	SELECT 'D�part'										AS 'Voyage',
		   NomNavire									AS 'Nom du navire',
		   FORMAT(DateHeureDepart, 'dd-MM-yyyy hh:mm')	AS 'Date et heure du voyage',
		   PortDestination								AS 'Port',
		   TypeCargaison								AS 'Type de cargaison'
	FROM Departs 
	WHERE MONTH(DateHeureDepart) = @mois 
	  AND YEAR(DateHeureDepart) = @annee
END
GO

-- Question 5.
