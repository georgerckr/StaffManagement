CREATE TABLE [dbo].[Staff] (
    [FullName]   VARCHAR (50) NOT NULL,
    [DateJoined] DATETIME     NULL,
    [StaffType]  TINYINT      NULL,
    [SID]        INT          IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([SID] ASC)
);





