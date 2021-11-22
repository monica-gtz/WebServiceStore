CREATE TABLE [dbo].[Estatus] (
    [EstatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Estatus] PRIMARY KEY CLUSTERED ([EstatusId] ASC)
);

