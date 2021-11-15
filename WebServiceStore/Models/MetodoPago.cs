using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public int MetodoPagoId { get; set; }
        public string Tarjeta { get; set; }
        public string Oxxo { get; set; }
        public string Paypal { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
