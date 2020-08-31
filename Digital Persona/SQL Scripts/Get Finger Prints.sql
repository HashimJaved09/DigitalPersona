IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetFingerPrints]') AND TYPE in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetFingerPrints]
GO

CREATE PROCEDURE GetFingerPrints
AS
BEGIN
	SELECT [iPersonID], [Right_Thumb] FROM Person WHERE [Right_Thumb] <> ''
END