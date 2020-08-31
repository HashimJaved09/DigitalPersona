IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPersons]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetPersons]
GO

CREATE PROCEDURE GetPersons
AS
BEGIN
	SELECT [iPersonID], [Name], [CNIC_Number], [Phone_Number], [Address] FROM Person
END