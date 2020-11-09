CREATE TABLE [dbo].[SupportStaff] (
    [Category] NVARCHAR (50) NULL,
    [SID]      INT           NOT NULL,
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_SupportStaff] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SupportStaff_Staff] FOREIGN KEY ([SID]) REFERENCES [dbo].[Staff] ([SID])
);





