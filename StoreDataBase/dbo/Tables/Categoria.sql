CREATE TABLE [dbo].[Categoria] (
    [CategoriaId] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion] NVARCHAR (200) NOT NULL,
    [Imagen]      NVARCHAR (50)  NOT NULL,
    [EstatusId]   INT            NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED ([CategoriaId] ASC),
    CONSTRAINT [FK_Categoria_Estatus_EstatusId] FOREIGN KEY ([EstatusId]) REFERENCES [dbo].[Estatus] ([EstatusId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Categoria_EstatusId]
    ON [dbo].[Categoria]([EstatusId] ASC);

