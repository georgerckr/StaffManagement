
-- =============================================  
-- Author:  George   
-- Create date: 06-011-2020  
-- Description: Procedure to implement bulk insertion of staffs   
-- =============================================  
CREATE PROCEDURE [dbo].[proc_BulkInsertStaff] @STableType StaffTableType READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from  
	-- interfering with SELECT statements.  
	SET NOCOUNT ON;

	DECLARE @Stype TINYINT;

	SELECT @Stype = StaffType
	FROM @STableType

	BEGIN TRY
		INSERT INTO Staff (
			FullName
			,DateJoined
			,StaffType
			)
		SELECT FullName
			,DateJoined
			,StaffType
		FROM @STableType

		SELECT @Stype

		INSERT INTO TeachingStaff (
			SID
			,Subject
			)
		SELECT S.SID
			,ST.Subject
		FROM Staff AS S
		INNER JOIN @STableType ST ON S.FullName = ST.FullName
			AND S.DateJoined = ST.DateJoined
			AND S.StaffType = ST.StaffType
		WHERE S.StaffType = 1

		INSERT INTO AdministrativeStaff (
			SID
			,Department
			,ROLE
			)
		SELECT S.SID
			,ST.Department
			,ST.ROLE
		FROM Staff AS S
		INNER JOIN @STableType ST ON S.FullName = ST.FullName
			AND S.DateJoined = ST.DateJoined
			AND S.StaffType = ST.StaffType
		WHERE S.StaffType = 2

		INSERT INTO SupportStaff (
			SID
			,Category
			)
		SELECT S.SID
			,ST.Category
		FROM Staff AS S
		INNER JOIN @STableType ST ON S.FullName = ST.FullName
			AND S.DateJoined = ST.DateJoined
			AND S.StaffType = ST.StaffType
		WHERE S.StaffType = 3
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber
			,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END