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

INSERT INTO [dbo].[Arrivees]
           ([NomNavire]
           ,[DateHeureArrivee]
           ,[PortOrigine]
           ,[Terminal]
           ,[TypeCargaison])
     VALUES
           ('Spirit'
           ,'2024-05-12 12:15:00.000'
           ,'New York'
           ,'1')
GO

INSERT INTO [dbo].[Departs]
           ([NomNavire]
           ,[DateHeureDepart]
           ,[PortDestination]
           ,[Quai]
           ,[TypeCargaison])
     VALUES
           ('Norvegian'
           ,'2024-03-01 01:30:00.000'
           ,'Montréal'
           ,72)
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
SELECT TOP 1 NomNavire FROM Arrivees
ORDER BY DateHeureArrivee DESC

---- 4.
SELECT * FROM Departs
WHERE Quai = 72 
	  AND YEAR(DateHeureDepart) = 2024
GO

---- Question 3
ALTER TABLE Arrivees ADD TypeCargaison nvarchar(max) NOT NULL DEFAULT 'Inconnu'
ALTER TABLE Departs ADD TypeCargaison nvarchar(max) NOT NULL DEFAULT 'Inconnu'
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
	SELECT 'Arrivée'		AS 'Voyage',
		   NomNavire,
		   DateHeureArrivee	AS 'DateHeureVoyage',
		   PortOrigine		AS 'Port',
		   TypeCargaison
	FROM Arrivees 
	WHERE MONTH(DateHeureArrivee) = @mois 
	  AND YEAR(DateHeureArrivee) = @annee

	UNION

	SELECT 'Départ'			AS 'Voyage',
		   NomNavire,								
		   DateHeureDepart	AS 'DateHeureVoyage',
		   PortDestination	AS 'Port',
		   TypeCargaison								
	FROM Departs 
	WHERE MONTH(DateHeureDepart) = @mois 
	  AND YEAR(DateHeureDepart) = @annee
END
GO

-- Question 5.
