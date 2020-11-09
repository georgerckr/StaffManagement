CREATE TABLE [dbo].[AdministrativeStaff] (
    [Department] NVARCHAR (50) NULL,
    [Role]       NVARCHAR (50) NULL,
    [SID]        INT           NOT NULL,
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_AdministrativeStaff] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AdministrativeStaff_Staff] FOREIGN KEY ([SID]) REFERENCES [dbo].[Staff] ([SID])
);





