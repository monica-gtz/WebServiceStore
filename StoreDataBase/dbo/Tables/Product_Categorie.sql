CREATE TABLE [dbo].[Product_Categorie] (
    [Product_CategorieId] INT IDENTITY (1, 1) NOT NULL,
    [ProductId]           INT NOT NULL,
    [CategorieId]         INT NOT NULL,
    CONSTRAINT [PK_Product_Categorie] PRIMARY KEY CLUSTERED ([Product_CategorieId] ASC),
    CONSTRAINT [FK_Product_Categorie_Categories] FOREIGN KEY ([CategorieId]) REFERENCES [dbo].[Categories] ([CategorieId]),
    CONSTRAINT [FK_Product_Categorie_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

