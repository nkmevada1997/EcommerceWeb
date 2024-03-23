CREATE TABLE [dbo].[Customers] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [FirstName]   NVARCHAR (MAX)   NOT NULL,
    [LastName]    NVARCHAR (MAX)   NULL,
    [DOB]         DATETIME2 (7)    NOT NULL,
    [Gender]      NVARCHAR (MAX)   NOT NULL,
    [Email]       NVARCHAR (MAX)   NOT NULL,
    [PhoneNumber] NVARCHAR (MAX)   NOT NULL,
    [Password]    NVARCHAR (MAX)   NOT NULL,
    [CountryId]   UNIQUEIDENTIFIER NOT NULL,
    [StateId]     UNIQUEIDENTIFIER NOT NULL,
    [CityId]      UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [UpdatedDate] DATETIME2 (7)    NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [IsRemoved]   BIT              NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customers_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([Id]),
    CONSTRAINT [FK_Customers_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id]),
    CONSTRAINT [FK_Customers_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Customers_StateId]
    ON [dbo].[Customers]([StateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Customers_CountryId]
    ON [dbo].[Customers]([CountryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Customers_CityId]
    ON [dbo].[Customers]([CityId] ASC);

