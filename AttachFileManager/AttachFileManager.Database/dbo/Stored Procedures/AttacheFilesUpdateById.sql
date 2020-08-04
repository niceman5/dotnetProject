IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesUpdateById')
	BEGIN
		DROP  Procedure  dbo.AttacheFilesUpdateById
	END
GO

CREATE PROCEDURE [dbo].[AttacheFilesUpdateById]
	@FileName	nvarchar(255) = '',
	@filesize	int	= 0,
	@id			int	= 0 
AS
	
	Update AttacheFiles
	set 
		FileName = @FileName
	,	FileSize = @filesize
	where 
		id = @id

go