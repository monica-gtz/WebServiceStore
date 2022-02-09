using System;
using System.Collections.Generic;
using WebServiceStore.Models;
using System.Threading.Tasks;

using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Services
{
    public class ProductoServices : IServices<Producto>
    {
        IDataAccess _data;

        public ProductoServices(IDataAccess data)
        {
            _data = data;
        }

        public Task<Producto> AddAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> DeleteAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            var parametros = new List<SqlParameter>();
            var data = await _data.ExecuteProcedureAsync("SP_GetAllProducts", parametros);

            return Map(data);
        }

        public async Task<Producto> GetById(Producto productoId)
        {
            var producto = new List<SqlParameter>();
           var data = await _data.ExecuteProcedureAsync("SP_GetProductById", producto);
            //throw new NotImplementedException();
            return Map(data)[0];
        }

        public List<Producto> Map(DataSet data)
        {
            List<Producto> resultados = new List<Producto>();
            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                resultados.AddRange(data.Tables[0]
                    .Rows.Cast<DataRow>()
                    .Select(registro => new Producto
                    {
                        ProductoId = int.Parse(registro["ProductoId"].ToString()),
                        Nombre = registro["Nombre"].ToString(),
                        Precio= decimal.Parse(registro["Precio"].ToString()),
                        Imagen= registro["Imagen"].ToString(),
                        EstatusId= int.Parse(registro["EstatusId"].ToString()),

                    }));

            }
            return resultados;
        }

        
        public Task<Producto> UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
