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