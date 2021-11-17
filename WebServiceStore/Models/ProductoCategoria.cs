using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models
{
    public class ProductoCategoria
    {
        [Key]
        [Required]
        public int ProductCategorieId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategorieId { get; set; }
    }
}
