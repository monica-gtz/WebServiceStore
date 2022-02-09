using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class Estatus
    {

        [Key]
        [Required]
        public int EstatusId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public List<Categoria> Categorias { get; set; }
        public List<Producto> Producto { get; set; }
    }
}
