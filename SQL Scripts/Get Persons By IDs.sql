IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPersonsByIDs]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetPersonsByIDs]
GO

CREATE PROCEDURE GetPersonsByIDs
@IDs idTable
AS
BEGIN
	SELECT [iPersonID], [Name], [CNIC_Number], [Guardian_CNIC], [Phone_Number], [Address], [Notes], [Image_Name], [Image_File], [Right_Thumb] FROM Person
	where iPersonID = @iPersonID
END


CREATE PROCEDURE SelectList (@IDs idTable READONLY) AS
SELECT * FROM sometable
INNER JOIN @IDs AS idTable ON idTable.id=sometable.id