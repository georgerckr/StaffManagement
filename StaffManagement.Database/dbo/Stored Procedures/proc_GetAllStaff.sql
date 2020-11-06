-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to get all staff from DB
-- =============================================
CREATE PROCEDURE [dbo].[proc_GetAllStaff]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.


     SELECT *
	FROM Staff AS S
	LEFT OUTER JOIN TeachingStaff AS T
	ON S.SID = T.ID
	LEFT OUTER JOIN AdministrativeStaff AS A
	ON S.SID = A.SID
	LEFT OUTER JOIN SupportStaff AS SU
	ON S.SID = SU.SID;
END