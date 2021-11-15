USE [StoreWebSite]
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[IsAvailable]
           ,[Image]
           ,[StatusId])
     VALUES
           ('Tenis Superstar'
           ,999.99
           ,'False'
           ,'tenisst.jpg'
           ,3)
GO


INSERT INTO [dbo].[Product_Categorie]
           ([ProductId]
           ,[CategorieId])
     VALUES
           (9
           ,3)
GO


INSERT INTO [dbo].[Categories]
           ([Descripcion]
           ,[Image]
           ,[StatusId])
     VALUES
           (Mujeres
           ,mujer.jpg
           ,1)
GO


INSERT INTO [dbo].[Domicilio]
           ([CodigoPostal]
           ,[Calle]
           ,[Colonia]
           ,[Ciudad]
           ,[Pais]
           ,[NumExt]
           ,[ClientId])
     VALUES
           (29130
           ,'3a sur'
           ,'Mirador'
           ,'Berriozabal'
           ,'México'
           ,'430'
           ,1)
GO



INSERT INTO [dbo].[ShopCar]
           ([Cantidad]
           ,[ProductId]
           ,[ClientId])
     VALUES
           (2499.99
           ,1
           ,1)
GO


INSERT INTO [dbo].[MetodoPago]
           ([Tarjeta]
           ,[Oxxo]
           ,[Paypal])
     VALUES
           ('Tarjeta Credito/Debito'
           ,'Oxxo'
           ,'Paypal')
GO


INSERT INTO [dbo].[Pedidos]
           ([Total]
           ,[ClientId]
           ,[DomicilioId]
           ,[MetodoPagoId])
     VALUES
           (2599.99
           ,2
           ,1
           ,1)
GO


INSERT INTO [dbo].[OrderDetails]
           ([Price]
           ,[Cantidad]
           ,[ProductId]
           ,[PedidoId])
     VALUES
           (2499.99
           ,2599.99
           ,1
           ,3)
GO
