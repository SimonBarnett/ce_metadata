USE [system]
GO
/****** Object:  UserDefinedFunction [dbo].[FormColumns]    Script Date: 16/12/2016 14:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[FormColumns] 
(
	@e int
)
RETURNS 
@T TABLE 
(
	CNAME VARCHAR(100),
	CPOS int,
	CTYPE VARCHAR(20),
	CWIDTH INT,
	CDECIMAL INT,
	CTITLE VARCHAR(20),
	CREADONLY VARCHAR(1),
	CHIDE VARCHAR(1),
	MANDATORY VARCHAR(1),
	REGEX varchar(max),
	BARCODE2D varchar(max)
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	INSERT INTO @T
	SELECT 		
				FORMCLMNS.NAME,
				FORMCLMNS.POS,
				CASE WHEN (COLUMNS.TYPE = '') THEN  dbo.FORMCLMNSA.TYPE ELSE COLUMNS.TYPE END,
				CASE WHEN (COLUMNS.WIDTH ='') THEN dbo.FORMCLMNS.WIDTH ELSE  COLUMNS.WIDTH END,	
				COLUMNSA.DECIMAL,						
				CASE WHEN (FORMCLMNS.TITLE = '') THEN COLUMNS.TITLE ELSE FORMCLMNS.TITLE END,
				CASE WHEN (FORMCLMNS.READONLY = 'R') THEN '' ELSE NULL END,
				CASE WHEN (FORMCLMNS.HIDE = 'H') THEN '' ELSE NULL END,
				CASE WHEN (FORMCLMNS.READONLY = 'M') THEN '' ELSE NULL END	,
				dbo.ColumnProperty(@e, FORMCLMNS.NAME, 'Regex'), 
				dbo.ColumnProperty(@e, FORMCLMNS.NAME,'2dBarcode')
	FROM         dbo.COLUMNSA RIGHT OUTER JOIN
                      dbo.COLUMNS INNER JOIN
                      dbo.FORMCLMNS ON dbo.COLUMNS.T$COLUMN = dbo.FORMCLMNS.T$COLUMN ON dbo.COLUMNSA.T$COLUMN = dbo.COLUMNS.T$COLUMN LEFT OUTER JOIN
                      dbo.FORMCLMNSA ON dbo.FORMCLMNS.FORM = dbo.FORMCLMNSA.FORM AND dbo.FORMCLMNS.NAME = dbo.FORMCLMNSA.NAME
	WHERE  FORMCLMNS.FORM = @e
	--AND FORMCLMNS.T$JOIN = 0
	and COLUMNS.CNAME not in ('RECORDTYPE','LINE','LOADED','KEY1','KEY2','KEY3','BUBBLEID','DUMMY','ME','TABLE')
	ORDER BY FORMCLMNS.POS
	RETURN 
END
