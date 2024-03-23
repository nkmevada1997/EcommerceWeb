CREATE TABLE [dbo].[Countries] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [UpdatedDate] DATETIME2 (7)    NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [IsRemoved]   BIT              NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([Id] ASC)
);

