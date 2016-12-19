USE [system]
GO
/****** Object:  UserDefinedFunction [dbo].[FormDef]    Script Date: 16/12/2016 14:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[FormDef]
(
	-- Add the parameters for the function here
	@FORM int
)
RETURNS xml
AS
BEGIN
	RETURN (
		SELECT
				ENAME AS "@name",
				TITLE AS "@title", 		
				INS as "@ins",		
				UPD as "@upd",
				DEL as "@del",
				   (SELECT CNAME     AS "@name", 
						   CTITLE    AS "@title",						   
						   CPOS      AS "@pos",
						   CREADONLY AS "@readonly", 
						   CHIDE     AS "@hidden", 
						   MANDATORY AS "@mandatory", 
						   REGEX     AS "@regex",
						   BARCODE2D AS "@barcode2d"
					FROM   dbo.FormColumns(@FORM) 
					FOR xml path('column'), type) ,
					(
						select dbo.FormDef(SONFORM)
						from FORMLINKS
						WHERE FATFORM = @FORM
						FOR xml path('ChildForms'), type
					)				  				    
				  
				  FROM dbo.T$EXEC
				  WHERE dbo.T$EXEC.T$EXEC = @FORM
			FOR xml path('form'), type
		)
END
