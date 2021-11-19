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
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        [Required]
        [ForeignKey("DomicilioId")]
        public Domicilio Domicilio { get; set; }
        
    }
}
