using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class Categories
    {
        public Categories()
        {
            ProductCategorie = new HashSet<ProductCategorie>();
        }

        public int CategorieId { get; set; }
        public string Descripcion { get; set; }
        public string Image { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<ProductCategorie> ProductCategorie { get; set; }
    }
}
