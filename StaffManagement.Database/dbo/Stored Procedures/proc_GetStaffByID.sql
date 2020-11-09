
-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to return a specific staff using staff ID from DB
-- =============================================
CREATE PROCEDURE [dbo].[proc_GetStaffByID] @SID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	BEGIN TRY
		SELECT *
		FROM Staff AS S
		LEFT OUTER JOIN TeachingStaff AS T ON S.SID = T.ID
		LEFT OUTER JOIN AdministrativeStaff AS A ON S.SID = A.SID
		LEFT OUTER JOIN SupportStaff AS SU ON S.SID = SU.SID
		WHERE S.SID = @SID;
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber
			,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END