--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesGetByBoardAndArticle')
--	BEGIN
--		DROP  Procedure  dbo.AttacheFilesGetByBoardAndArticle
--	END
--GO

CREATE PROCEDURE [dbo].[AttacheFilesGetByBoardAndArticle]
	@BoardId	int = 0,
	@ArticleId	int	= 0
AS
	select *
	from AttacheFiles
	where BoarId = @BoardId 
	and ArticleId = @ArticleId
	order by FileName asc
	;
go