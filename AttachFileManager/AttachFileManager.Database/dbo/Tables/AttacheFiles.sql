CREATE TABLE [dbo].[AttacheFiles]
(
	[Id]	INT		NOT NULL PRIMARY KEY	IDENTITY(1,1),		--일련번호
	UserId	int		null	,									--사용자id
	BoarId	INT		not null	,								--게시판 테이블 일련번호
	ArticleId	int	not null	,								--게시펀 아티클 일련번호
	FileName	nvarchar(255)	null,							--파일명(확장자 포함)
	FileSize	int	null,										--파일크기
	DownCount	int	Default 0,									--다운수
	TimeStamp	DateTimeoffset(7)	default(getdate())	null	--업로드시간
)
