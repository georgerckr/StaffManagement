﻿-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to return a specific staff using staff ID from DB
-- =============================================

CREATE PROCEDURE [dbo].[proc_GetStaffByID]
@SID int
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
	ON S.SID = SU.SID
	WHERE S.SID =@SID;
END