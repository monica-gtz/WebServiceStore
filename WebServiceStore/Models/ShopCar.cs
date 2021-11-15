using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class ShopCar
    {
        public int ShopcarId { get; set; }
        public int Cantidad { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }

        public virtual Products Product { get; set; }
    }
}
