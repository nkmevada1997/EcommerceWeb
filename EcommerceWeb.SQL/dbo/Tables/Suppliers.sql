CREATE TABLE [dbo].[Suppliers] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NOT NULL,
    [Email]       NVARCHAR (MAX)   NOT NULL,
    [Password]    NVARCHAR (MAX)   NOT NULL,
    [CountryId]   UNIQUEIDENTIFIER NOT NULL,
    [StateId]     UNIQUEIDENTIFIER NOT NULL,
    [CityId]      UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [UpdatedDate] DATETIME2 (7)    NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [IsRemoved]   BIT              NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Suppliers_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([Id]),
    CONSTRAINT [FK_Suppliers_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id]),
    CONSTRAINT [FK_Suppliers_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Suppliers_StateId]
    ON [dbo].[Suppliers]([StateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Suppliers_CountryId]
    ON [dbo].[Suppliers]([CountryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Suppliers_CityId]
    ON [dbo].[Suppliers]([CityId] ASC);

