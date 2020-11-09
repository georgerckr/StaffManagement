
-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to Add a new staff 
-- =============================================
CREATE PROCEDURE [dbo].[proc_InsertStaff] @FullName NVARCHAR(50)
	,@DateJoined DATETIME
	,@StaffType TINYINT
	,@Department NVARCHAR(50) = NULL
	,@Role NVARCHAR(50) = NULL
	,@Category NVARCHAR(50) = NULL
	,@Subject NVARCHAR(50) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		INSERT INTO Staff (
			FullName
			,DateJoined
			,StaffType
			)
		VALUES (
			@FullName
			,@DateJoined
			,@StaffType
			);

		IF @StaffType = 1
		BEGIN
			INSERT INTO TeachingStaff (
				SID
				,Subject
				)
			VALUES (
				(
					SELECT SCOPE_IDENTITY()
					)
				,@Subject
				);
		END

		IF @StaffType = 2
		BEGIN
			INSERT INTO AdministrativeStaff (
				SID
				,Department
				,ROLE
				)
			VALUES (
				(
					SELECT SCOPE_IDENTITY()
					)
				,@Department
				,@Role
				);
		END

		IF @StaffType = 3
		BEGIN
			INSERT INTO SupportStaff (
				SID
				,Category
				)
			VALUES (
				(
					SELECT SCOPE_IDENTITY()
					)
				,@Category
				);
		END
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber
			,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END