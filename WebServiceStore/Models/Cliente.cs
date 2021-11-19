using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        public string Mail { get; set; }
        
        public List<Domicilio> Domicilios { get; set; }
        public List<Carrito> Carritos { get; set; }
        public List<Pedidos> Pedidos { get; set; }
    }
}
