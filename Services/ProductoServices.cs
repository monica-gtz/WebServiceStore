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

        

        public async Task<List<Producto>> GetAllAsync()
        {
            var parametros = new List<SqlParameter>();
            var data = await _data.ExecuteProcedureAsync("SP_GetAllProducts", parametros);

            return Map(data);
        }

        public async Task<Producto> GetById(Producto productoId)
        {
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@ProductoId", productoId.ProductoId);
            parameters.Add(p);
            var data = await _data.ExecuteProcedureAsync("SP_GetProductById", parameters);
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
        
        public async Task<Producto> AddAsync(Producto newProducto)
        {
            var newProduct = new Producto();
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@Nombre", newProducto.Nombre);
            parameters.Add(p);
            p = new SqlParameter("@Precio", newProducto.Precio);
            parameters.Add(p);
            p = new SqlParameter("@Imagen", newProducto.Imagen);
            parameters.Add(p);
            p = new SqlParameter("@EstatusId", newProducto.EstatusId);
            parameters.Add(p);

            var data = await _data.ExecuteProcedureAsync("SP_AddProduct", parameters);
            //throw new NotImplementedException();

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                //Si to do sale correctamente se pone el 1 como resultado
                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["ProductoId"].ToString());
                newProduct = await this.GetById(new Producto() { ProductoId = resultado }); 
            }

            return newProduct;
  
        }


        public Task<Producto> UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> DeleteAsync(int productoId)
        {
            var newProduct = new Producto();
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@ProductoId", productoId);
            parameters.Add(p);

            var data = await _data.ExecuteProcedureAsync("SP_DeleteProduct", parameters);

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                //Si to do sale correctamente se pone el 1 como resultado
                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["Result"].ToString());
                newProduct = await this.GetById(new Producto() { ProductoId = resultado });
            }
            return newProduct;
            //throw new NotImplementedException();
        }
    }
}
