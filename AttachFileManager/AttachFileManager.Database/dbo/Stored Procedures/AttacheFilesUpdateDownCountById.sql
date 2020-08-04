--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesUpdateDownCountById')
--	BEGIN
--		DROP  Procedure  dbo.AttacheFilesUpdateDownCountById
--	END
--GO

CREATE PROCEDURE [dbo].[AttacheFilesUpdateDownCountById]
	@id	int	= 0
AS
	update AttacheFiles
	set DownCount = DownCount + 1
	where Id = @id

go
