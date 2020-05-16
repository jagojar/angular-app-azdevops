CREATE TABLE [dbo].[BlogPosts] (
    [PostId]  INT            IDENTITY (1, 1) NOT NULL,
    [Creator] NVARCHAR (MAX) NOT NULL,
    [Title]   NVARCHAR (MAX) NOT NULL,
    [Body]    NVARCHAR (MAX) NOT NULL,
    [Dt]      DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED ([PostId] ASC)
);

