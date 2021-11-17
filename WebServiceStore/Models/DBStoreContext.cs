using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class DBStoreContext : DbContext
    {
        public DBStoreContext(DbContextOptions<DBStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Domicilio> Domicilio { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<ProductoCategoria> ProductoCategorias { get; set; }
    }
}
