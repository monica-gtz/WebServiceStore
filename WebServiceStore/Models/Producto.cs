using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class Producto
    {
        [Key]
        [Required]
        public int ProductoId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
        [Required]
        [StringLength(50)]
        public string Imagen { get; set; }
        [Required]
        public int EstatusId { get; set; }
        [ForeignKey("EstatusId")]
        public Estatus Estatus { get; set; }


        public List<ProductoCategoria> ProductoCategorias { get; set; }
        public List<Carrito> Carrito { get; set; }
    }
}
