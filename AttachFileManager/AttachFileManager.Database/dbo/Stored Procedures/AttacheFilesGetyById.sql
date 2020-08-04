IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesGetyById')
	BEGIN
		DROP  Procedure  dbo.AttacheFilesGetyById
	END
GO

CREATE PROCEDURE [dbo].[AttacheFilesGetyById]
	@Id		int	= 0
AS
	
	select * from AttacheFiles where Id= @Id;
go
