IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertPerson]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertPerson]
GO

CREATE PROCEDURE InsertPerson
@name varchar(100),
@guardian varchar(13) = '',
@cnic varchar(13),
@phone varchar(11) = '',
@address varchar(500),
@notes varchar(5000),
@right_thumb varchar(8000),
@image_name varchar(500) = '',
@image_file image = 0x0
AS
BEGIN
	IF Not Exists (SELECT TOP 1 * FROM Person where CNIC_Number = @cnic)
		INSERT INTO Person (Name, Guardian_CNIC, CNIC_Number, Phone_Number, Address, Right_Thumb, Notes, Image_Name, Image_File)
		VALUES (@name, @guardian, @cnic, @phone, @address, @right_thumb, @notes, @image_name, @image_file);
END