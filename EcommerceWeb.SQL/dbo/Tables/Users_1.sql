CREATE TABLE [dbo].[Users] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [UserName]    NVARCHAR (MAX)   NOT NULL,
    [Email]       NVARCHAR (MAX)   NOT NULL,
    [Password]    NVARCHAR (MAX)   NOT NULL,
    [UserType]    INT              NOT NULL,
    [CanLogin]    BIT              NOT NULL,
    [CustomerId]  UNIQUEIDENTIFIER NULL,
    [SupplierId]  UNIQUEIDENTIFIER NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [UpdatedDate] DATETIME2 (7)    NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    [IsRemoved]   BIT              NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [FK_Users_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_SupplierId]
    ON [dbo].[Users]([SupplierId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Users_CustomerId]
    ON [dbo].[Users]([CustomerId] ASC);

