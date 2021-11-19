using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class DetallePedido
    {
        [Key]
        [Required]
        public int DetallePedidoId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [ForeignKey("ProductoId")]
        public Producto Producto{ get; set; }
        [Required]
        [ForeignKey("PedidoId")]
        public Pedidos Pedidos { get; set; }
    }
}
