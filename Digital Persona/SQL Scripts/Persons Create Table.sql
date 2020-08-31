CREATE TABLE Person (
	iPersonID int identity(1,1) not null primary key,
	Name varchar(100) not null,
	Guardian_CNIC varchar(13) Default(''),
	CNIC_Number varchar(13) not null UNIQUE,
	Phone_Number varchar(11) Default(''),
	Address varchar(500) not null,
	Image_Name varchar(500) Default(''),
	Image_File image Default(0x0),
	Right_Thumb varchar(8000) not null,
	Notes varchar(5000) Default(''),
	Relationship varchar(100) Default(''),
	Relationship_CNIC varchar(13) Default('')
)