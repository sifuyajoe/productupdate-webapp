CREATE TABLE [dbo].[upwebapp] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [prodName]         NVARCHAR (MAX)  NULL,
    [prodPrice]        DECIMAL (18, 2) NOT NULL,
    [prodDescription]  NVARCHAR (MAX)  NULL,
    [prodSupplierName] NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_upwebapp] PRIMARY KEY CLUSTERED ([Id] ASC)
);

