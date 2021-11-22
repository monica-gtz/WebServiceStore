CREATE TABLE [dbo].[MetodoPago] (
    [MetodoPagoId] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion]  NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_MetodoPago] PRIMARY KEY CLUSTERED ([MetodoPagoId] ASC)
);



