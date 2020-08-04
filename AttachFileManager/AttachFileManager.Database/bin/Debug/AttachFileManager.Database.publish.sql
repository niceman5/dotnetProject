/*
dev의 배포 스크립트

이 코드는 도구를 사용하여 생성되었습니다.
파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
변경 내용이 손실됩니다.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "dev"
:setvar DefaultFilePrefix "dev"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
SQLCMD 모드가 지원되지 않으면 SQLCMD 모드를 검색하고 스크립트를 실행하지 않습니다.
SQLCMD 모드를 설정한 후에 이 스크립트를 다시 사용하려면 다음을 실행합니다.
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'이 스크립트를 실행하려면 SQLCMD 모드를 사용하도록 설정해야 합니다.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'[dbo].[AttacheFiles]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[AttacheFiles] (
    [Id]        INT                IDENTITY (1, 1) NOT NULL,
    [UserId]    INT                NULL,
    [BoarId]    INT                NOT NULL,
    [ArticleId] INT                NOT NULL,
    [FileName]  NVARCHAR (255)     NULL,
    [FileSize]  INT                NULL,
    [DownCount] INT                NULL,
    [TimeStamp] DATETIMEOFFSET (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[AttacheFiles]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[AttacheFiles]
    ADD DEFAULT 0 FOR [DownCount];


GO
PRINT N'[dbo].[AttacheFiles]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[AttacheFiles]
    ADD DEFAULT (getdate()) FOR [TimeStamp];


GO
PRINT N'[dbo].[AttacheFilesGetByBoardAndArticle]을(를) 만드는 중...';


GO
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
GO
PRINT N'[dbo].[AttacheFilesGetByFileName]을(를) 만드는 중...';


GO
--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesGetByFileName')
--	BEGIN
--		DROP  Procedure  dbo.AttacheFilesGetByFileName
--	END
--GO

CREATE PROCEDURE [dbo].[AttacheFilesGetByFileName]
	@FileName	nvarchar(255)	=''
AS
	
	declare	
	@sql	nvarchar(max);

	set @sql = '
		select * from AttacheFiles Where
		FileName Like ''%' + @FileName + '%'' order by FileName ASC
	'

	exec(@sql)
GO
PRINT N'[dbo].[AttacheFilesGetyById]을(를) 만드는 중...';


GO
--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesGetyById')
--	BEGIN
--		DROP  Procedure  dbo.AttacheFilesGetyById
--	END
--GO

CREATE PROCEDURE [dbo].[AttacheFilesGetyById]
	@Id		int	= 0
AS
	
	select * from AttacheFiles where Id= @Id;
GO
PRINT N'[dbo].[AttacheFilesRemoveById]을(를) 만드는 중...';


GO
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
PRINT N'[dbo].[AttacheFilesUpdateById]을(를) 만드는 중...';


GO
--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AttacheFilesUpdateById')
--	BEGIN
--		DROP  Procedure  dbo.AttacheFilesUpdateById
--	END
--GO

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
GO
PRINT N'[dbo].[AttacheFilesUpdateDownCountById]을(를) 만드는 중...';


GO
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
GO
PRINT N'[dbo].[AttachFileAdd]을(를) 만드는 중...';


GO
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
PRINT N'[dbo].[AttachFilesGetAll]을(를) 만드는 중...';


GO
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
PRINT N'업데이트가 완료되었습니다.';


GO
