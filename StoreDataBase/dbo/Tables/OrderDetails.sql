CREATE TABLE [dbo].[OrderDetails] (
    [DetallePedidoId] INT             IDENTITY (1, 1) NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [Cantidad]        INT             NOT NULL,
    [ProductId]       INT             NOT NULL,
    [PedidoId]        INT             NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([DetallePedidoId] ASC),
    CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

