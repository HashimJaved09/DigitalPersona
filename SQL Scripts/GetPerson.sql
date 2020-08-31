IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPerson]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetPerson]
GO

CREATE PROCEDURE GetPerson
@iPersonID int = 0
AS
BEGIN
	SELECT [iPersonID], [Name], [CNIC_Number], [Guardian_CNIC], [Phone_Number], [Address], [Notes], [Image_Name], [Image_File], [Right_Thumb] FROM Person
	where iPersonID = @iPersonID
END