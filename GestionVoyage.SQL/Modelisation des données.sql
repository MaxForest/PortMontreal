-- Question 1.
CREATE DATABASE GestionVoyage;
GO

USE [GestionVoyage]
CREATE TABLE Trajets(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[NomNavire] nvarchar(30) NOT NULL,
	[Depart_Date] DATETIME NOT NULL,
	[Depart_PortDestinationId] int NOT NULL,
	[Depart_Quai] INT NOT NULL,
	[Arrivee_Date] DATETIME NULL,
	[Arrivee_PortOrigineId] int NULL,
	[Arrivee_Terminal] INT NULL)
GO

CREATE TABLE Ports(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nom] nvarchar(30) NOT NULL)
GO

ALTER TABLE Trajets  WITH CHECK ADD  CONSTRAINT [FK_.Trajets_Depart_PortId] FOREIGN KEY([Depart_Port_Id])
REFERENCES Ports ([Id])
ON DELETE NO ACTION
GO

ALTER TABLE Trajets  WITH CHECK ADD  CONSTRAINT [FK_.Trajets_Arrivee_PortId] FOREIGN KEY([Arrivee_Port_Id])
REFERENCES Ports ([Id])
ON DELETE NO ACTION
GO

-- Question 2.
---- 1.
DECLARE @moisEnCours int = MONTH(GETDATE()),
		@anneeEnCours int = YEAR(GETDATE())

SELECT * FROM Trajets 
WHERE MONTH(Depart_Date) = @moisEnCours 
	  AND YEAR(Depart_Date) = @anneeEnCours
GO

---- 2.
SELECT COUNT(*) FROM Trajets t
INNER JOIN Ports p on t.Depart_Port_Id = p.Id
WHERE p.Nom = 'New York'
GO

---- 3.
SELECT TOP 1 t.NomNavire FROM Trajets t
ORDER BY t.Arrivee_Date DESC

---- 4.
SELECT * FROM Trajets
WHERE Depart_Quai = 72 
	  AND YEAR(Depart_Date) = 2024
GO

---- Question 3
ALTER TABLE Trajets ADD TypeCargaison int NOT NULL DEFAULT 0
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
	SELECT *
	FROM Trajets
	WHERE (MONTH(Depart_Date) = @mois 
	  AND YEAR(Depart_Date) = @annee) OR
	      (MONTH(Arrivee_Date) = @mois 
	  AND YEAR(Arrivee_Date) = @annee)
END
GO

EXEC GenererRapportMensuel @mois = 5, @annee = 2024