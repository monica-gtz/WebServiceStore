using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class OrderDetails
    {
        public int DetallePedidoId { get; set; }
        public decimal Price { get; set; }
        public int Cantidad { get; set; }
        public int ProductId { get; set; }
        public int PedidoId { get; set; }

        public virtual Pedidos Pedido { get; set; }
        public virtual Products Product { get; set; }
    }
}
