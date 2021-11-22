CREATE TABLE [dbo].[Domicilio] (
    [DomicilioId]  INT           IDENTITY (1, 1) NOT NULL,
    [CodigoPostal] INT           NOT NULL,
    [Calle]        NVARCHAR (50) NOT NULL,
    [Colonia]      NVARCHAR (50) NOT NULL,
    [Ciudad]       NVARCHAR (50) NOT NULL,
    [Estado]       NVARCHAR (50) NOT NULL,
    [Pais]         NVARCHAR (50) NOT NULL,
    [NumExt]       NVARCHAR (10) NOT NULL,
    [ClienteId]    INT           NOT NULL,
    CONSTRAINT [PK_Domicilio] PRIMARY KEY CLUSTERED ([DomicilioId] ASC),
    CONSTRAINT [FK_Domicilio_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([ClienteId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Domicilio_ClienteId]
    ON [dbo].[Domicilio]([ClienteId] ASC);

