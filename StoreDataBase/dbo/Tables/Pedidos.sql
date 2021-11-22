CREATE TABLE [dbo].[Pedidos] (
    [PedidoId]     INT             IDENTITY (1, 1) NOT NULL,
    [Total]        DECIMAL (18, 2) NOT NULL,
    [ClienteId]    INT             NOT NULL,
    [MetodoPagoId] INT             NOT NULL,
    [DomicilioId]  INT             NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED ([PedidoId] ASC),
    CONSTRAINT [FK_Pedidos_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([ClienteId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Pedidos_Domicilio_DomicilioId] FOREIGN KEY ([DomicilioId]) REFERENCES [dbo].[Domicilio] ([DomicilioId]),
    CONSTRAINT [FK_Pedidos_MetodoPago_MetodoPagoId] FOREIGN KEY ([MetodoPagoId]) REFERENCES [dbo].[MetodoPago] ([MetodoPagoId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Pedidos_MetodoPagoId]
    ON [dbo].[Pedidos]([MetodoPagoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Pedidos_DomicilioId]
    ON [dbo].[Pedidos]([DomicilioId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Pedidos_ClienteId]
    ON [dbo].[Pedidos]([ClienteId] ASC);

