﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebServiceStore.Models;

#nullable disable

namespace WebServiceStore.Migrations
{
    [DbContext(typeof(DBStoreContext))]
    [Migration("20211122183217_store2")]
    partial class store2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebServiceStore.Models.Carrito", b =>
                {
                    b.Property<int>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoId"), 1L, 1);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClienteId")
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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("EstatusId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoriaId");

                    b.HasIndex("EstatusId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("WebServiceStore.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("WebServiceStore.Models.DetallePedido", b =>
                {
                    b.Property<int>("DetallePedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetallePedidoId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DomicilioId"), 1L, 1);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoPostal")
                        .HasColumnType("int");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumExt")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DomicilioId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Domicilio");
                });

            modelBuilder.Entity("WebServiceStore.Models.Estatus", b =>
                {
                    b.Property<int>("EstatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstatusId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EstatusId");

                    b.ToTable("Estatus");
                });

            modelBuilder.Entity("WebServiceStore.Models.MetodoPago", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetodoPagoId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MetodoPagoId");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("WebServiceStore.Models.Pedidos", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("DomicilioId")
                        .HasColumnType("int");

                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"), 1L, 1);

                    b.Property<int>("EstatusId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductoId");

                    b.HasIndex("EstatusId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("WebServiceStore.Models.ProductoCategoria", b =>
                {
                    b.Property<int>("ProductCategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoriaId"), 1L, 1);

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

                    b.Navigation("Cliente");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebServiceStore.Models.Categoria", b =>
                {
                    b.HasOne("WebServiceStore.Models.Estatus", "Estatus")
                        .WithMany("Categorias")
                        .HasForeignKey("EstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
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

                    b.Navigation("Pedidos");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebServiceStore.Models.Domicilio", b =>
                {
                    b.HasOne("WebServiceStore.Models.Cliente", "Clientes")
                        .WithMany("Domicilios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
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

                    b.Navigation("Cliente");

                    b.Navigation("Domicilio");

                    b.Navigation("MetodoPago");
                });

            modelBuilder.Entity("WebServiceStore.Models.Producto", b =>
                {
                    b.HasOne("WebServiceStore.Models.Estatus", "Estatus")
                        .WithMany("Producto")
                        .HasForeignKey("EstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
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

                    b.Navigation("Categoria");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebServiceStore.Models.Categoria", b =>
                {
                    b.Navigation("ProductoCategorias");
                });

            modelBuilder.Entity("WebServiceStore.Models.Cliente", b =>
                {
                    b.Navigation("Carritos");

                    b.Navigation("Domicilios");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("WebServiceStore.Models.Domicilio", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("WebServiceStore.Models.Estatus", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebServiceStore.Models.MetodoPago", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("WebServiceStore.Models.Pedidos", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("WebServiceStore.Models.Producto", b =>
                {
                    b.Navigation("Carrito");

                    b.Navigation("DetallePedidos");

                    b.Navigation("ProductoCategorias");
                });
#pragma warning restore 612, 618
        }
    }
}
