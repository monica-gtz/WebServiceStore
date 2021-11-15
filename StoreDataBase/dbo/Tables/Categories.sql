CREATE TABLE [dbo].[Categories] (
    [CategorieId] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (500)  NOT NULL,
    [Image]       VARCHAR (1000) NOT NULL,
    [StatusId]    INT            NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategorieId] ASC),
    CONSTRAINT [FK_Categories_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([StatusId])
);

