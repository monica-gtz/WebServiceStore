USE [Store]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Telefono], [Mail]) VALUES (1, N'Lizeth', N'9611601429', N'monica.gtzm@hotmail.com')
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Telefono], [Mail]) VALUES (4, N'Jose', N'9611303133', N'pepegtz@gmail.com')
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Telefono], [Mail]) VALUES (5, N'Monicaaaa', N'55484212', N'moni@hotmail.com')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Domicilio] ON 

INSERT [dbo].[Domicilio] ([DomicilioId], [CodigoPostal], [Calle], [Colonia], [Ciudad], [Estado], [Pais], [NumExt], [ClienteId]) VALUES (1, 29130, N'2a oriente sur', N'Santa Cruz', N'Berriozabal', N'Chiapas', N'Mexico', N's/n', 1)
INSERT [dbo].[Domicilio] ([DomicilioId], [CodigoPostal], [Calle], [Colonia], [Ciudad], [Estado], [Pais], [NumExt], [ClienteId]) VALUES (3, 29130, N'3a sur poniente', N'Mirador', N'Berriozabal', N'Chiapas', N'Mexico', N'430', 4)
SET IDENTITY_INSERT [dbo].[Domicilio] OFF
GO
SET IDENTITY_INSERT [dbo].[MetodoPago] ON 

INSERT [dbo].[MetodoPago] ([MetodoPagoId], [Descripcion]) VALUES (1, N'Oxxo')
INSERT [dbo].[MetodoPago] ([MetodoPagoId], [Descripcion]) VALUES (2, N'Paypalssss')
SET IDENTITY_INSERT [dbo].[MetodoPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedidos] ON 

INSERT [dbo].[Pedidos] ([PedidoId], [Total], [ClienteId], [MetodoPagoId], [DomicilioId]) VALUES (1, CAST(1399.90 AS Decimal(18, 2)), 4, 1, 3)
INSERT [dbo].[Pedidos] ([PedidoId], [Total], [ClienteId], [MetodoPagoId], [DomicilioId]) VALUES (3, CAST(1699.90 AS Decimal(18, 2)), 1, 1, 3)
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Estatus] ON 

INSERT [dbo].[Estatus] ([EstatusId], [Description]) VALUES (1, N'Disponible')
INSERT [dbo].[Estatus] ([EstatusId], [Description]) VALUES (3, N'Agotado')
SET IDENTITY_INSERT [dbo].[Estatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ProductoId], [Nombre], [Precio], [Imagen], [EstatusId]) VALUES (2, N'Vans', CAST(1599.90 AS Decimal(18, 2)), N'vans.jpg', 1)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Carrito] ON 

INSERT [dbo].[Carrito] ([CarritoId], [Cantidad], [ProductoId], [ClienteId]) VALUES (1, CAST(2.00 AS Decimal(18, 2)), 2, 4)
INSERT [dbo].[Carrito] ([CarritoId], [Cantidad], [ProductoId], [ClienteId]) VALUES (2, CAST(3.00 AS Decimal(18, 2)), 2, 5)
SET IDENTITY_INSERT [dbo].[Carrito] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([CategoriaId], [Descripcion], [Imagen], [EstatusId]) VALUES (1, N'Hombres', N'hombres.jpg', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductoCategorias] ON 

INSERT [dbo].[ProductoCategorias] ([ProductCategoriaId], [ProductoId], [CategoriaId]) VALUES (1, 2, 1)
SET IDENTITY_INSERT [dbo].[ProductoCategorias] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallePedido] ON 

INSERT [dbo].[DetallePedido] ([DetallePedidoId], [Price], [Cantidad], [ProductoId], [PedidoId]) VALUES (1, CAST(1299.90 AS Decimal(18, 2)), 4, 2, 1)
SET IDENTITY_INSERT [dbo].[DetallePedido] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211121220248_Store', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122183217_store2', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122183350_store3', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122184005_store4', N'6.0.0')
GO
