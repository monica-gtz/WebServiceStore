CREATE TABLE [dbo].[Status] (
    [StatusId]    INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

