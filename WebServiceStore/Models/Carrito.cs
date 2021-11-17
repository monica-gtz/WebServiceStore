using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class Carrito
    {
        [Key]
        [Required]
        public int CarritoId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public int Cantidad { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int ClienteId { get; set; }
    }
}
