
-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to Update Staff Details 
-- =============================================
CREATE PROCEDURE [dbo].[proc_UpdateStaff] @SID INT
	,@FullName NVARCHAR(50)
	,@DateJoined DATETIME
	,@Department NVARCHAR(50) = NULL
	,@Role NVARCHAR(50) = NULL
	,@Category NVARCHAR(50) = NULL
	,@Subject NVARCHAR(50) = NULL
AS
BEGIN
	DECLARE @StaffType TINYINT = (
			SELECT StaffType
			FROM Staff
			WHERE SID = @SID
			)

	BEGIN TRY
		UPDATE Staff
		SET FullName = @FullName
			,DateJoined = @DateJoined
		WHERE SID = @SID;

		IF @StaffType = 1
		BEGIN
			UPDATE TeachingStaff
			SET Subject = @Subject
			WHERE SID = @SID;
		END

		IF @StaffType = 2
		BEGIN
			UPDATE AdministrativeStaff
			SET ROLE = @Role
				,Department = @Department
			WHERE SID = @SID;
		END

		IF @StaffType = 3
		BEGIN
			UPDATE SupportStaff
			SET Category = @Category
			WHERE SID = @SID;
		END
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber
			,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END