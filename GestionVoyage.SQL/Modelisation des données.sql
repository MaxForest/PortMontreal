-- Question 1.
CREATE DATABASE GestionVoyage;
GO

USE [GestionVoyage]
CREATE TABLE Trajets(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[NomNavire] nvarchar(max) NOT NULL)
GO

CREATE TABLE Arrivees(
	[Id] INT PRIMARY KEY NOT NULL,
	[DateHeureArrivee] DATETIME NOT NULL,
	[PortOrigine] nvarchar(max) NOT NULL,
	[Terminal] INT NOT NULL)
GO

CREATE TABLE Departs(
	[Id] INT PRIMARY KEY NOT NULL,
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
GO

---- 2.
SELECT COUNT(*) FROM Arrivees
WHERE PortOrigine = 'New York'
GO

---- 3.
SELECT TOP 1 t.NomNavire FROM Arrivees a
join Trajets t on t.Id = a.Id
ORDER BY DateHeureArrivee DESC

---- 4.
SELECT * FROM Departs
WHERE Quai = 72 
	  AND YEAR(DateHeureDepart) = 2024
GO

---- Question 3
ALTER TABLE Trajets ADD TypeCargaison nvarchar(max) NOT NULL DEFAULT 'Inconnu'
GO

-- Question 4.
-- =============================================
-- Author:		Maxime Aubin-Forest
-- Create date: 2024-05-16
-- Description:	Le Port de Montréal souhaite automatiser la génération d’un rapport mensuel sur les voyages effectués par les différents navires.
-- EXEC GenererRapportMensuel @mois = 5, @annee = 2024
-- =============================================
CREATE OR ALTER PROCEDURE GenererRapportMensuel
	-- Add the parameters for the stored procedure here
	@mois int,
	@annee int
AS
BEGIN
	SELECT 'Arrivée'		AS 'Trajet',
		   a.NomNavire,
		   DateHeureArrivee	AS 'DateHeureVoyage',
		   PortOrigine		AS 'Port',
		   a.TypeCargaison
	FROM Arrivees a
	join trajets t on t.Id = a.Id
	WHERE MONTH(DateHeureArrivee) = @mois 
	  AND YEAR(DateHeureArrivee) = @annee

	UNION

	SELECT 'Départ'			AS 'Trajet',
		   d.NomNavire,								
		   DateHeureDepart	AS 'DateHeureVoyage',
		   PortDestination	AS 'Port',
		   d.TypeCargaison								
	FROM Departs d
	join trajets t on t.Id = d.Id
	WHERE MONTH(DateHeureDepart) = @mois 
	  AND YEAR(DateHeureDepart) = @annee
END
GO

EXEC GenererRapportMensuel @mois = 5, @annee = 2024