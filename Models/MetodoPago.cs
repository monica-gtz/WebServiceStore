using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class MetodoPago
    {
        [Key]
        [Required]
        public int MetodoPagoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public List<Pedidos> Pedidos { get; set; }
        
    }
}
