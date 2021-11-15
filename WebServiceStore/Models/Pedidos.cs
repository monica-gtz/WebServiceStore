using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int PedidoId { get; set; }
        public decimal Total { get; set; }
        public int ClientId { get; set; }
        public int DomicilioId { get; set; }
        public int MetodoPagoId { get; set; }

        public virtual MetodoPago MetodoPago { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
