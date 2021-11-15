CREATE TABLE [dbo].[Products] (
    [ProductId]   INT             IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (200)   NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [IsAvailable] BIT             NOT NULL,
    [Image]       VARCHAR (1000)  NOT NULL,
    [StatusId]    INT             NOT NULL,
    CONSTRAINT [PK_Products_1] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Products_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([StatusId])
);

