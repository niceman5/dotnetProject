CREATE TABLE [dbo].[USERS]
(
	USER_NO              integer		NOT NULL		IDENTITY	PRIMARY KEY,
	USER_NM              varchar(30)	NOT NULL ,
	ID                   varchar(20)	NOT NULL ,
	PW                   varchar(20)	NOT NULL ,
	HDPH_NO              varchar(20)	NOT NULL ,
	EMAIL                varchar(50)	NULL ,
	IS_DEL               bit			NOT NULL		DEFAULT	0,
	LAST_CHNG_DT         datetime		NOT NULL		DEFAULT GETDATE(),
	LAST_USER_NO         integer		NOT NULL 
);
