CREATE TABLE [dbo].[ShopCar] (
    [ShopcarId] INT IDENTITY (1, 1) NOT NULL,
    [Cantidad]  INT NOT NULL,
    [ProductId] INT NOT NULL,
    [ClientId]  INT NOT NULL,
    CONSTRAINT [PK_ShopCar] PRIMARY KEY CLUSTERED ([ShopcarId] ASC),
    CONSTRAINT [FK_ShopCar_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

