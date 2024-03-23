CREATE TABLE [dbo].[Cities] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NOT NULL,
    [StateId]     UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [UpdatedDate] DATETIME2 (7)    NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [IsRemoved]   BIT              NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cities_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Cities_StateId]
    ON [dbo].[Cities]([StateId] ASC);

