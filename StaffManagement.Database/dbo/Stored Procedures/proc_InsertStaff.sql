-- =============================================
-- Author:		George
-- Create date: 05/11/2020
-- Description:	procedure to Add a new staff 
-- =============================================

CREATE PROCEDURE [dbo].[proc_InsertStaff]

@FullName varchar(50),
@DateJoined datetime,
@StaffType tinyint,
@Department varchar(50) = NULL,
@Role varchar(50) = NULL,
@Category varchar(50) = NULL,
@Subject varchar(50) = NULL

AS 

BEGIN
SET NOCOUNT ON;
INSERT INTO Staff(FullName,DateJoined,StaffType)
	VALUES (@FullName,@DateJoined,@StaffType);

IF @StaffType = 1
BEGIN

	INSERT INTO TeachingStaff(SID,Subject)
	VALUES ((SELECT SCOPE_IDENTITY()),@Subject);
END

IF @StaffType = 2
BEGIN 
	INSERT INTO AdministrativeStaff(SID,Department,Role)
	VALUES ((SELECT SCOPE_IDENTITY()),@Department,@Role);
END

IF @StaffType = 3
BEGIN 
	INSERT INTO SupportStaff(SID,Category)
	VALUES ((SELECT SCOPE_IDENTITY()),@Category);
END

END