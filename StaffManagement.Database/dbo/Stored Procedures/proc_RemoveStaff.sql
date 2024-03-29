﻿
-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to remove a staff from DB
-- =============================================
CREATE PROCEDURE [dbo].[proc_RemoveStaff] @SID INT
AS
BEGIN
	DECLARE @StaffType TINYINT = (
			SELECT StaffType
			FROM Staff
			WHERE SID = @SID
			)

	BEGIN TRY
		IF @StaffType = 1
		BEGIN
			DELETE
			FROM TeachingStaff
			WHERE SID = @SID;
		END

		IF @StaffType = 2
		BEGIN
			DELETE
			FROM AdministrativeStaff
			WHERE SID = @SID;
		END

		IF @StaffType = 3
		BEGIN
			DELETE
			FROM SupportStaff
			WHERE SID = @SID;
		END

		DELETE
		FROM Staff
		WHERE SID = @SID;
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber
			,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END