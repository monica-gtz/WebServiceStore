using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class ProductCategorie
    {
        public int ProductCategorieId { get; set; }
        public int ProductId { get; set; }
        public int CategorieId { get; set; }

        public virtual Categories Categorie { get; set; }
        public virtual Products Product { get; set; }
    }
}
