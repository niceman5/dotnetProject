CREATE TABLE [dbo].[CODE_DICT]
(	
	CODE                 varchar(10)	NOT NULL	PRIMARY KEY,
	CODE_CATE_NO         integer		NOT NULL ,
	CODE_NM              varchar(100)	NOT NULL ,
	IS_DEL               bit			NOT NULL	DEFAULT 0,
	LAST_CHNG_DT         datetime		NOT NULL	DEFAULT GETDATE(),
	LAST_USER_NO         integer		NOT NULL, 
    CONSTRAINT [FK_CODE_DICT_CODE_CATES] FOREIGN KEY ([CODE_CATE_NO]) REFERENCES [CODE_CATES]([CODE_CATE_NO]) 	
)
