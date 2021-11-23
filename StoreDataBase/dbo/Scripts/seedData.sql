/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [Store]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Telefono], [Mail]) VALUES (4, N'Jose', N'9611303133', N'pepegtz@gmail.com')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Telefono], [Mail]) VALUES (5, N'Monicaaaa', N'55484212', N'moni@hotmail.com')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Estatus] ON 
GO
INSERT [dbo].[Estatus] ([EstatusId], [Description]) VALUES (1, N'Disponible')
GO
SET IDENTITY_INSERT [dbo].[Estatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([ProductoId], [Nombre], [Precio], [Imagen], [EstatusId]) VALUES (2, N'Vans', CAST(1599.90 AS Decimal(18, 2)), N'vans.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([CategoriaId], [Descripcion], [Imagen], [EstatusId]) VALUES (1, N'Hombres', N'hombres.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211121220248_Store', N'6.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122183217_store2', N'6.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122183350_store3', N'6.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122184005_store4', N'6.0.0')
GO
