CREATE TABLE [dbo].[TeachingStaff] (
    [Subject] VARCHAR (50) NULL,
    [SID]     INT          NOT NULL,
    [ID]      INT          IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_TeachingStaff] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TeachingStaff_Staff] FOREIGN KEY ([SID]) REFERENCES [dbo].[Staff] ([SID])
);





