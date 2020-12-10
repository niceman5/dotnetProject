CREATE TABLE [dbo].[BOARDS]
(
	BOARD_NO             integer		NOT NULL		 IDENTITY	PRIMARY KEY,
	BOARD_TYPE_CD        varchar(10)	NOT NULL ,
	UP_BOARD_NO          integer		NULL ,
	USER_NO              integer		NOT NULL ,
	TITLE                varchar(100)	NOT NULL ,
	CONT                 varchar(MAX)	NOT NULL ,
	IS_DEL               bit			NOT NULL		DEFAULT 0,	
	LAST_CHNG_DT         datetime		NOT NULL		DEFAULT GETDATE(),
	LAST_USER_NO         integer		NOT NULL, 
    CONSTRAINT [FK_BOARDS_USERS] FOREIGN KEY ([USER_NO]) REFERENCES [USERS]([USER_NO]) 
);
