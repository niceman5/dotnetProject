--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttachFilesGetAll')
--BEGIN
--	DROP  Procedure  dbo.AttachFilesGetAll
--END
--GO

CREATE PROCEDURE [dbo].[AttachFilesGetAll]
	@pageNumber int	= 1,	
	@PageSize	int	= 10
AS
	
	select
	*
	from AttacheFiles order by id desc
	offset ((@pageNumber - 1) * @PageSize) row fetch next @pagesize rows only
	;
GO
