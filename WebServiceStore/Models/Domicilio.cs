using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class Domicilio
    {
        [Key]
        [Required]
        public int DomicilioId { get; set; }
        [Required]
        public int CodigoPostal { get; set; }
        [Required]
        [StringLength(50)]
        public string Calle { get; set; }
        [Required]
        [StringLength(50)]
        public string Colonia { get; set; }
        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        [Required]
        [StringLength(10)]
        public string NumExt { get; set; }
        [Required]
        [ForeignKey("ClienteId")]
        public Cliente Clientes { get; set; }

        public List<Pedidos> Pedidos { get; set; }
    }
}
