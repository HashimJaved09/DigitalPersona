IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPersonLessData]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetPersonLessData]
GO

CREATE PROCEDURE GetPersonLessData
@iPersonID int = 0
AS
BEGIN
	SELECT [iPersonID], [Name], [CNIC_Number], [Phone_Number], [Address] FROM Person
	where iPersonID = @iPersonID
END