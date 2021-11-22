CREATE TABLE [dbo].[ProductoCategorias] (
    [ProductCategoriaId] INT IDENTITY (1, 1) NOT NULL,
    [ProductoId]         INT NOT NULL,
    [CategoriaId]        INT NULL,
    CONSTRAINT [PK_ProductoCategorias] PRIMARY KEY CLUSTERED ([ProductCategoriaId] ASC),
    CONSTRAINT [FK_ProductoCategorias_Categoria_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categoria] ([CategoriaId]),
    CONSTRAINT [FK_ProductoCategorias_Producto_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductoCategorias_ProductoId]
    ON [dbo].[ProductoCategorias]([ProductoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProductoCategorias_CategoriaId]
    ON [dbo].[ProductoCategorias]([CategoriaId] ASC);

