CREATE TABLE [dbo].[Logs] (
    [Id]           INT            NOT NULL,
    [LogMessage]   NVARCHAR (500) NOT NULL,
    [CreationDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

