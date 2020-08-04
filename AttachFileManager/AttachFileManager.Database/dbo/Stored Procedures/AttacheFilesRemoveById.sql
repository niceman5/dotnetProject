--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesRemoveById')
--	BEGIN
--		DROP  Procedure  dbo.AttacheFilesRemoveById
--	END
--GO

CREATE PROCEDURE [dbo].[AttacheFilesRemoveById]
	@Id		int	= 0
AS
	
	Delete AttacheFiles where Id = @Id

GO
