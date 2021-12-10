using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceStore.Models;

namespace WebServiceStore.ViewModels
{
    public class AddCategorieView
    {
        public int CategoriaId { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Imagen { get; set; }


        public Estatus EstatusSelected { get; set; }
        public List<Estatus> ListaEstatus { get; set; }
    }
}
