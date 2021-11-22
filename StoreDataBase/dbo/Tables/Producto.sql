CREATE TABLE [dbo].[Producto] (
    [ProductoId] INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]     NVARCHAR (50)   NOT NULL,
    [Precio]     DECIMAL (18, 2) NOT NULL,
    [Imagen]     NVARCHAR (50)   NOT NULL,
    [EstatusId]  INT             NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([ProductoId] ASC),
    CONSTRAINT [FK_Producto_Estatus_EstatusId] FOREIGN KEY ([EstatusId]) REFERENCES [dbo].[Estatus] ([EstatusId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Producto_EstatusId]
    ON [dbo].[Producto]([EstatusId] ASC);

