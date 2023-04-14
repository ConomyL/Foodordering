USE [YZProject]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Category_Crud]
		@Action = NULL,
		@CategoryId = NULL,
		@UserName = NULL,
		@IsActive = NULL,
		@ImageUrl = NULL

SELECT	@return_value as 'Return Value'

GO
