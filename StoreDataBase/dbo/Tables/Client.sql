CREATE TABLE [dbo].[Client] (
    [ClientId]    INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (100) NOT NULL,
    [phone]       VARCHAR (50)  NOT NULL,
    [mail]        VARCHAR (100) NOT NULL,
    [DomicilioId] INT           NOT NULL,
    CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED ([ClientId] ASC),
    CONSTRAINT [FK_Client_Domicilio] FOREIGN KEY ([DomicilioId]) REFERENCES [dbo].[Domicilio] ([DomicilioId])
);

