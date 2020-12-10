﻿USE DEV
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.upBOARD_LIST') AND type in (N'P', N'PC'))
	DROP PROCEDURE dbo.upBOARD_LIST
GO

/*
upBOARD_LIST 
*/

CREATE PROCEDURE [dbo].[upBOARD_LIST]
(
	@USER_NO		INT
,	@SEARCH_KEY		VARCHAR(100)	= ''
,	@PAGE			INT = 1		--조회 PAGE
,	@CNT_PAGE		INT = 20	--PAGE당 조회건수
)
AS
SET NOCOUNT ON;
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;	

--최산건부터 조회되게 수정함
SELECT
	A.[BOARD_NO]
,	A.[BOARD_TYPE_CD]
,	A.[UP_BOARD_NO]
,	A.[USER_NO]
,	A.[TITLE]
,	A.[CONT]
,	(		
		SELECT 
			AA.ATACH_NO
		,	AA.FILE_NM
		,	AA.FILE_SIZE
		,	AA.DOWN_CNT
		FROM dbo.BOARD_ATACH_FILES	AA 
		WHERE AA.BOARD_NO = A.BOARD_NO
		FOR JSON PATH , INCLUDE_NULL_VALUES
	)	ATACH_FILES_JSON
FROM DBO.BOARDS A
WHERE A.IS_DEL = 0
AND (
		@SEARCH_KEY = ''
		OR
		(
			A.[TITLE] LIKE '%'+@SEARCH_KEY+'%'
			OR
			A.[CONT] LIKE '%'+@SEARCH_KEY+'%'
		)
	)
ORDER BY A.[USER_NO] DESC
OFFSET ((@PAGE-1) * @CNT_PAGE) ROWS
FETCH NEXT @CNT_PAGE ROWS ONLY
;