using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Imagen { get; set; }
        [Required]
        public int EstatusId { get; set; }
        [ForeignKey("EstatusId")]
        public Estatus Estatus { get; set; }
        public List<ProductoCategoria> ProductoCategorias { get; set; }
    }
}
