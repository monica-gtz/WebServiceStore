using System;
using System.Collections.Generic;

namespace WebServiceStore.Models
{
    public partial class Domicilio
    {
        public Domicilio()
        {
            Client = new HashSet<Client>();
        }

        public int DomicilioId { get; set; }
        public int CodigoPostal { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string NumExt { get; set; }
        public int ClientId { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
