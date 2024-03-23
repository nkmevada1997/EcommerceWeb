CREATE TABLE [dbo].[States] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NOT NULL,
    [CountryId]   UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [UpdatedDate] DATETIME2 (7)    NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [IsRemoved]   BIT              NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_States_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_States_CountryId]
    ON [dbo].[States]([CountryId] ASC);

