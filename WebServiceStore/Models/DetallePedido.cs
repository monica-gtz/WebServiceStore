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
        public int ProductId { get; set; }
        [Required]
        public int PedidoId { get; set; }
    }
}
