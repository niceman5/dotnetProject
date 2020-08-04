--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttachFileAdd')
--	BEGIN
--		DROP  Procedure  dbo.AttachFileAdd
--	END

--GO

CREATE PROCEDURE [dbo].[AttachFileAdd]
(
	@UserId		int	= 0
,	@BoardId	int	= 0
,	@ArticleId	int	= 0
,	@FileName	NVarchar(255)	= ''
,	@FileSize	int	= 0
)
AS
	
	insert into AttacheFiles
		( UserId, BoarId, ArticleId, FileName, FileSize)
	values
		( @UserId, @BoardId, @ArticleId, @FileName, @FileSize)

GO
