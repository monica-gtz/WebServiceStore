CREATE TABLE [dbo].[Cliente] (
    [ClienteId] INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]    NVARCHAR (100) NOT NULL,
    [Telefono]  NVARCHAR (50)  NOT NULL,
    [Mail]      NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([ClienteId] ASC)
);

