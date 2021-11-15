CREATE TABLE [dbo].[Domicilio] (
    [DomicilioId]  INT          IDENTITY (1, 1) NOT NULL,
    [CodigoPostal] INT          NOT NULL,
    [Calle]        VARCHAR (50) NOT NULL,
    [Colonia]      VARCHAR (50) NOT NULL,
    [Ciudad]       VARCHAR (50) NOT NULL,
    [Pais]         VARCHAR (50) NOT NULL,
    [NumExt]       VARCHAR (50) NOT NULL,
    [ClientId]     INT          NOT NULL,
    CONSTRAINT [PK_Domicilio] PRIMARY KEY CLUSTERED ([DomicilioId] ASC)
);

