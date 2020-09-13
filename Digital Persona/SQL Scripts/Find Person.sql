IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FindPerson]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[FindPerson]
GO

CREATE PROCEDURE FindPerson
@name varchar(100) = '',
@cnic varchar(13) = '',
@phone varchar(11) = '',
@guardian varchar(13) = ''
AS
BEGIN
	SELECT [iPersonID], [Name], [CNIC_Number], [Phone_Number], [Address] FROM Person
	where Name like '%' + @name + '%' and CNIC_Number like '%' + @cnic + '%' and Phone_Number like '%' + @phone + '%' and Guardian_CNIC like '%' + @guardian + '%'
END