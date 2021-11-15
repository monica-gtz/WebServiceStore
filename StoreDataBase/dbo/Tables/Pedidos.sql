CREATE TABLE [dbo].[Pedidos] (
    [PedidoId]     INT             IDENTITY (1, 1) NOT NULL,
    [Total]        DECIMAL (18, 2) NOT NULL,
    [ClientId]     INT             NOT NULL,
    [DomicilioId]  INT             NOT NULL,
    [MetodoPagoId] INT             NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED ([PedidoId] ASC),
    CONSTRAINT [FK_Pedidos_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([ClientId]),
    CONSTRAINT [FK_Pedidos_Domicilio] FOREIGN KEY ([DomicilioId]) REFERENCES [dbo].[Domicilio] ([DomicilioId]),
    CONSTRAINT [FK_Pedidos_MetodoPago1] FOREIGN KEY ([MetodoPagoId]) REFERENCES [dbo].[MetodoPago] ([MetodoPagoId])
);

