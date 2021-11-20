﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebServiceStore.Models;

namespace WebServiceStore.Migrations
{
    [DbContext(typeof(DBStoreContext))]
    [Migration("20211119211911_Store")]
    partial class Store
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebServiceStore.Models.Carrito", b =>
                {
                    b.Property<int>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("CarritoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("WebServiceStore.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("EstatusId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CategoriaId");

                    b.HasIndex("EstatusId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("WebServiceStore.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("WebServiceStore.Models.DetallePedido", b =>
                {
                    b.Property<int>("DetallePedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ProductoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("DetallePedidoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("WebServiceStore.Models.Domicilio", b =>
                {
                    b.Property<int>("DomicilioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("CodigoPostal")
                        .HasColumnType("int");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NumExt")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("DomicilioId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Domicilio");
                });

            modelBuilder.Entity("WebServiceStore.Models.Estatus", b =>
                {
                    b.Property<int>("EstatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("EstatusId");

                    b.ToTable("Estatus");
                });

            modelBuilder.Entity("WebServiceStore.Models.MetodoPago", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MetodoPagoId");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("WebServiceStore.Models.Pedidos", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("DomicilioId")
                        .HasColumnType("int");

                    b.Property<int?>("MetodoPagoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DomicilioId");

                    b.HasIndex("MetodoPagoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebServiceStore.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstatusId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ProductoId");

                    b.HasIndex("EstatusId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("WebServiceStore.Models.ProductoCategoria", b =>
                {
                    b.Property<int>("ProductCategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("ProductCategoriaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductoCategorias");
                });

            modelBuilder.Entity("WebServiceStore.Models.Carrito", b =>
                {
                    b.HasOne("WebServiceStore.Models.Cliente", "Cliente")
                        .WithMany("Carritos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebServiceStore.Models.Producto", "Producto")
                        .WithMany("Carrito")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebServiceStore.Models.Categoria", b =>
                {
                    b.HasOne("WebServiceStore.Models.Estatus", "Estatus")
                        .WithMany("Categorias")
                        .HasForeignKey("EstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebServiceStore.Models.DetallePedido", b =>
                {
                    b.HasOne("WebServiceStore.Models.Pedidos", "Pedidos")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebServiceStore.Models.Producto", "Producto")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebServiceStore.Models.Domicilio", b =>
                {
                    b.HasOne("WebServiceStore.Models.Cliente", "Clientes")
                        .WithMany("Domicilios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebServiceStore.Models.Pedidos", b =>
                {
                    b.HasOne("WebServiceStore.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebServiceStore.Models.Domicilio", "Domicilio")
                        .WithMany("Pedidos")
                        .HasForeignKey("DomicilioId");

                    b.HasOne("WebServiceStore.Models.MetodoPago", "MetodoPago")
                        .WithMany("Pedidos")
                        .HasForeignKey("MetodoPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebServiceStore.Models.Producto", b =>
                {
                    b.HasOne("WebServiceStore.Models.Estatus", "Estatus")
                        .WithMany("Producto")
                        .HasForeignKey("EstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebServiceStore.Models.ProductoCategoria", b =>
                {
                    b.HasOne("WebServiceStore.Models.Categoria", "Categoria")
                        .WithMany("ProductoCategorias")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("WebServiceStore.Models.Producto", "Producto")
                        .WithMany("ProductoCategorias")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}