using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class Pedidos
    {
        [Key]
        [Required]
        public int PedidoId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        [Required]
        public int MetodoPagoId { get; set; }
        [ForeignKey("MetodoPagoId")]
        public MetodoPago MetodoPago { get; set; }
        public int DomicilioId { get; set; }
        [ForeignKey("MetodoPagoId")]
        public virtual Domicilio Domicilio { get; set; }

        public List<DetallePedido> DetallePedidos { get; set; }
    }
}
