using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceStore.Models;

namespace WebServiceStore.ViewModels
{
    public class AddProductView
    {
  
        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Imagen { get; set; }
       
       
     
        public Estatus EstatusSelected { get; set; }
        public Categoria CategoriaSelected { get; set; }
        public List<Categoria> ListaCategoria { get; set; }

        public List<Estatus> ListaEstatus { get; set; }
    }
}
