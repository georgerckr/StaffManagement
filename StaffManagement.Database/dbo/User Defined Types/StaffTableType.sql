CREATE TYPE [dbo].[StaffTableType] AS TABLE (
    [FullName]   NVARCHAR (50) NOT NULL,
    [DateJoined] DATETIME      NULL,
    [StaffType]  TINYINT       NULL,
    [Department] NVARCHAR (50) NULL,
    [Role]       NVARCHAR (50) NULL,
    [Subject]    NVARCHAR (50) NULL,
    [Category]   NVARCHAR (50) NULL);

