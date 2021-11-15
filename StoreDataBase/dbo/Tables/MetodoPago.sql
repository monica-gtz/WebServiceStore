CREATE TABLE [dbo].[MetodoPago] (
    [MetodoPagoId] INT          IDENTITY (1, 1) NOT NULL,
    [Tarjeta]      VARCHAR (50) NOT NULL,
    [Oxxo]         VARCHAR (50) NOT NULL,
    [Paypal]       VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MetodoPago] PRIMARY KEY CLUSTERED ([MetodoPagoId] ASC)
);

