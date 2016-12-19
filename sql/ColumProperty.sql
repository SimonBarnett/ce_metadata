USE [system]
GO
/****** Object:  UserDefinedFunction [dbo].[ColumnProperty]    Script Date: 19/12/2016 10:02:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		si
-- Create date: 17/07/2013
-- Description:	Gets a property value for the 
--				specified column
-- =============================================
ALTER FUNCTION [dbo].[ColumnProperty]
(
	-- Add the parameters for the function here
	@e int,
	@Col varchar(max),
	@Property varchar(max)
)
RETURNS varchar(256)
AS
BEGIN
	declare @result varchar(64)
	declare @lang int
	set @lang = (select LANG FROM LANGUAGES WHERE LANGNAME = @Property)
	set @result = (
		SELECT TITLE from LANGFORMCLMNS 
		where FORM = @e 	
		and LANG = @lang
		and NAME = @Col
	)
	
	return @result
END
