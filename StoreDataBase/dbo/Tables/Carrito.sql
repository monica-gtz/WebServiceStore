CREATE TABLE [dbo].[Carrito] (
    [CarritoId]  INT             IDENTITY (1, 1) NOT NULL,
    [Cantidad]   DECIMAL (18, 2) NOT NULL,
    [ProductoId] INT             NOT NULL,
    [ClienteId]  INT             NOT NULL,
    CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED ([CarritoId] ASC),
    CONSTRAINT [FK_Carrito_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([ClienteId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Carrito_Producto_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Carrito_ProductoId]
    ON [dbo].[Carrito]([ProductoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Carrito_ClienteId]
    ON [dbo].[Carrito]([ClienteId] ASC);

