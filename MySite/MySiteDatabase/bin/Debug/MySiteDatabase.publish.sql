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
PRINT N'키가 78461b12-adbb-4867-96af-5ee2c813dc44인 이름 바꾸기 리팩터링 작업을 건너뜁니다. 요소 [dbo].[FK_CODE_DICT_ToTable](SqlForeignKeyConstraint)의 이름이 [FK_CODE_DICT_CODE_CATES](으)로 바뀌지 않습니다.';


GO
PRINT N'[dbo].[BOARD_ATACH_FILES]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[BOARD_ATACH_FILES] (
    [ATACH_NO]     INT           IDENTITY (1, 1) NOT NULL,
    [BOARD_NO]     INT           NOT NULL,
    [FILE_NM]      VARCHAR (250) NOT NULL,
    [FILE_SIZE]    INT           NOT NULL,
    [DOWN_CNT]     INT           NOT NULL,
    [LAST_CHNG_DT] DATETIME      NOT NULL,
    [LAST_USER_NO] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ATACH_NO] ASC)
);


GO
PRINT N'[dbo].[BOARDS]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[BOARDS] (
    [BOARD_NO]      INT           IDENTITY (1, 1) NOT NULL,
    [BOARD_TYPE_CD] VARCHAR (10)  NOT NULL,
    [UP_BOARD_NO]   INT           NULL,
    [USER_NO]       INT           NOT NULL,
    [TITLE]         VARCHAR (100) NOT NULL,
    [CONT]          VARCHAR (MAX) NOT NULL,
    [IS_DEL]        BIT           NOT NULL,
    [LAST_CHNG_DT]  DATETIME      NOT NULL,
    [LAST_USER_NO]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([BOARD_NO] ASC)
);


GO
PRINT N'[dbo].[CODE_CATES]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[CODE_CATES] (
    [CODE_CATE_NO] INT          IDENTITY (1, 1) NOT NULL,
    [CATE_NM]      VARCHAR (20) NOT NULL,
    [IS_DEL]       BIT          NOT NULL,
    [LAST_CHNG_DT] DATETIME     NOT NULL,
    [LAST_USER_NO] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([CODE_CATE_NO] ASC)
);


GO
PRINT N'[dbo].[CODE_CATES].[IX_CODE_CATES_CAT_NM]을(를) 만드는 중...';


GO
CREATE NONCLUSTERED INDEX [IX_CODE_CATES_CAT_NM]
    ON [dbo].[CODE_CATES]([CATE_NM] ASC);


GO
PRINT N'[dbo].[CODE_DICT]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[CODE_DICT] (
    [CODE]         VARCHAR (10)  NOT NULL,
    [CODE_CATE_NO] INT           NOT NULL,
    [CODE_NM]      VARCHAR (100) NOT NULL,
    [IS_DEL]       BIT           NOT NULL,
    [LAST_CHNG_DT] DATETIME      NOT NULL,
    [LAST_USER_NO] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([CODE] ASC)
);


GO
PRINT N'[dbo].[USERS]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[USERS] (
    [USER_NO]      INT          IDENTITY (1, 1) NOT NULL,
    [USER_NM]      VARCHAR (30) NOT NULL,
    [ID]           VARCHAR (20) NOT NULL,
    [PW]           VARCHAR (20) NOT NULL,
    [HDPH_NO]      VARCHAR (20) NOT NULL,
    [EMAIL]        VARCHAR (50) NULL,
    [IS_DEL]       BIT          NOT NULL,
    [LAST_CHNG_DT] DATETIME     NOT NULL,
    [LAST_USER_NO] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([USER_NO] ASC)
);


GO
PRINT N'[dbo].[BOARD_ATACH_FILES]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[BOARD_ATACH_FILES]
    ADD DEFAULT GETDATE() FOR [LAST_CHNG_DT];


GO
PRINT N'[dbo].[BOARDS]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[BOARDS]
    ADD DEFAULT 0 FOR [IS_DEL];


GO
PRINT N'[dbo].[BOARDS]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[BOARDS]
    ADD DEFAULT GETDATE() FOR [LAST_CHNG_DT];


GO
PRINT N'[dbo].[CODE_CATES]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[CODE_CATES]
    ADD DEFAULT 0 FOR [IS_DEL];


GO
PRINT N'[dbo].[CODE_CATES]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[CODE_CATES]
    ADD DEFAULT GETDATE() FOR [LAST_CHNG_DT];


GO
PRINT N'[dbo].[CODE_DICT]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[CODE_DICT]
    ADD DEFAULT 0 FOR [IS_DEL];


GO
PRINT N'[dbo].[CODE_DICT]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[CODE_DICT]
    ADD DEFAULT GETDATE() FOR [LAST_CHNG_DT];


GO
PRINT N'[dbo].[USERS]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[USERS]
    ADD DEFAULT 0 FOR [IS_DEL];


GO
PRINT N'[dbo].[USERS]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[USERS]
    ADD DEFAULT GETDATE() FOR [LAST_CHNG_DT];


GO
PRINT N'[dbo].[FK_BOARD_ATACH_FILES_BOARDS]을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[BOARD_ATACH_FILES] WITH NOCHECK
    ADD CONSTRAINT [FK_BOARD_ATACH_FILES_BOARDS] FOREIGN KEY ([BOARD_NO]) REFERENCES [dbo].[BOARDS] ([BOARD_NO]);


GO
PRINT N'[dbo].[FK_BOARDS_USERS]을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[BOARDS] WITH NOCHECK
    ADD CONSTRAINT [FK_BOARDS_USERS] FOREIGN KEY ([USER_NO]) REFERENCES [dbo].[USERS] ([USER_NO]);


GO
PRINT N'[dbo].[FK_CODE_DICT_CODE_CATES]을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[CODE_DICT] WITH NOCHECK
    ADD CONSTRAINT [FK_CODE_DICT_CODE_CATES] FOREIGN KEY ([CODE_CATE_NO]) REFERENCES [dbo].[CODE_CATES] ([CODE_CATE_NO]);


GO
-- 배포된 트랜잭션 로그를 사용하여 대상 서버를 업데이트하는 리팩터링 단계

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '78461b12-adbb-4867-96af-5ee2c813dc44')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('78461b12-adbb-4867-96af-5ee2c813dc44')

GO

GO
PRINT N'새로 만든 제약 조건에 대해 기존 데이터를 검사하는 중입니다.';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[BOARD_ATACH_FILES] WITH CHECK CHECK CONSTRAINT [FK_BOARD_ATACH_FILES_BOARDS];

ALTER TABLE [dbo].[BOARDS] WITH CHECK CHECK CONSTRAINT [FK_BOARDS_USERS];

ALTER TABLE [dbo].[CODE_DICT] WITH CHECK CHECK CONSTRAINT [FK_CODE_DICT_CODE_CATES];


GO
PRINT N'업데이트가 완료되었습니다.';


GO
