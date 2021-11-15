using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Models.Configuration
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public string URL_Encuesta { get; set; }
    }
}
