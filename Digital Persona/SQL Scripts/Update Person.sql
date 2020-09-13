IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdatePerson]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdatePerson]
GO

CREATE PROCEDURE UpdatePerson
@iPersonID int,
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
	IF Exists (SELECT 1 FROM Person)
		UPDATE Person SET
			Name = @name,
			Guardian_CNIC = @guardian,
			CNIC_Number = @cnic,
			Phone_Number = @phone,
			Address = @address,
			Right_Thumb = @right_thumb,
			Notes = @notes,
			Image_Name = @image_name,
			Image_File = @image_file
		WHERE iPersonID = @iPersonID;
END