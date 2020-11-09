CREATE TABLE [dbo].[Staff] (
    [FullName]   NVARCHAR (50) NOT NULL,
    [DateJoined] DATETIME      NULL,
    [StaffType]  TINYINT       NOT NULL,
    [SID]        INT           IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([SID] ASC)
);







