CREATE TABLE [dbo].[DetallePedido] (
    [DetallePedidoId] INT             IDENTITY (1, 1) NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [Cantidad]        INT             NOT NULL,
    [ProductoId]      INT             NOT NULL,
    [PedidoId]        INT             NOT NULL,
    CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED ([DetallePedidoId] ASC),
    CONSTRAINT [FK_DetallePedido_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedidos] ([PedidoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_DetallePedido_Producto_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DetallePedido_ProductoId]
    ON [dbo].[DetallePedido]([ProductoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DetallePedido_PedidoId]
    ON [dbo].[DetallePedido]([PedidoId] ASC);

