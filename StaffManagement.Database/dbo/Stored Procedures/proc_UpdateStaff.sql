-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to Update Staff Details 
-- =============================================
CREATE PROCEDURE [dbo].[proc_UpdateStaff]
@SID int,
@FullName varchar(50),
@DateJoined datetime,
@Department varchar(50) = NULL,
@Role varchar(50) = NULL,
@Category varchar(50) = NULL,
@Subject varchar(50) = NULL

AS
BEGIN

	
    DECLARE @StaffType TINYINT = (SELECT StaffType FROM Staff WHERE SID = @SID)
	UPDATE  Staff
	SET
	FullName =@FullName,
	DateJoined = @DateJoined
	WHERE SID = @SID;

	IF @StaffType = 1
	BEGIN
		UPDATE TeachingStaff
		SET
		Subject=@Subject
		WHERE SID = @SID;
	END

	IF @StaffType = 2
	BEGIN
		UPDATE AdministrativeStaff
		SET
		Role = @Role,
		Department=@Department
		WHERE SID = @SID;
	END

   IF @StaffType = 3
	BEGIN
		UPDATE SupportStaff
		SET
		Category=@Category
		WHERE SID = @SID;
	END

END