using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductCategorie = new HashSet<ProductCategorie>();
            ShopCar = new HashSet<ShopCar>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Image { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductCategorie> ProductCategorie { get; set; }
        public virtual ICollection<ShopCar> ShopCar { get; set; }
    }
}
