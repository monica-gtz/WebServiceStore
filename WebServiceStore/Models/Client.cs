using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int DomicilioId { get; set; }

        public virtual Domicilio Domicilio { get; set; }
    }
}
