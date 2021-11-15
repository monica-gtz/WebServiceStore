using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class Status
    {
        public Status()
        {
            Categories = new HashSet<Categories>();
            Products = new HashSet<Products>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
