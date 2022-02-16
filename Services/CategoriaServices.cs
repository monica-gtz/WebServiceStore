using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceStore.Models;

namespace Services
{
    public class CategoriaServices : IServices<Categoria>
    {
        IDataAccess _data;
        public CategoriaServices(IDataAccess data)
        {
            _data = data;
        }
        
        public async Task<List<Categoria>> GetAllAsync()
        {
            var parametros = new List<SqlParameter>();
            var data = await _data.ExecuteProcedureAsync("SP_GetAllCategories", parametros);

            return Map(data);
            //throw new NotImplementedException();
        }

        public List<Categoria> Map(DataSet data)
        {
            List<Categoria> resultados = new List<Categoria>();
            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                resultados.AddRange(data.Tables[0]
                    .Rows.Cast<DataRow>()
                    .Select(registro => new Categoria
                    {
                        CategoriaId = int.Parse(registro["CategoriaId"].ToString()),
                        Descripcion = registro["Descripcion"].ToString(),
                        Imagen = registro["Imagen"].ToString(),
                        EstatusId = int.Parse(registro["EstatusId"].ToString()),

                    }));

            }
            return resultados;
        }

        public async Task<Categoria> AddAsync(Categoria newCategoria)
        {
            var categoria = new Categoria();
            var parameters = new List<SqlParameter>();

            var p = new SqlParameter("@Descripcion", newCategoria.Descripcion);
            parameters.Add(p);
            p = new SqlParameter("@Imagen", newCategoria.Imagen);
            parameters.Add(p);
            p = new SqlParameter("@EstatusId", newCategoria.EstatusId);
            parameters.Add(p);

            var data = await _data.ExecuteProcedureAsync("SP_AddCategory", parameters);

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                //Si to do sale correctamente se pone el 1 como resultado
                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["CategoriaId"].ToString());
                categoria = await this.GetById(new Categoria() { CategoriaId = resultado });
            }

            return categoria;
            //throw new NotImplementedException();
        }

        public async Task<Categoria> GetById(Categoria categoriaId)
        {
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@CategoriaId", categoriaId.CategoriaId);
            parameters.Add(p);
            var data = await _data.ExecuteProcedureAsync("SP_GetCategoryById", parameters);
            //throw new NotImplementedException();
            return Map(data)[0];
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@CategoriaId", categoria.CategoriaId);
            parameters.Add(p);
            p = new SqlParameter("@Descripcion", categoria.Descripcion);
            parameters.Add(p);
            p = new SqlParameter("@Imagen", categoria.Imagen);
            parameters.Add(p);
            p = new SqlParameter("@EstatusId", categoria.EstatusId);
            parameters.Add(p);

            var data = await _data.ExecuteProcedureAsync("SP_EditCategory", parameters);

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                //Si todo sale correctamente se pone el 1 como resultado
                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["Result"].ToString());
                //product = await this.GetById(new Producto() { ProductoId = resultado });
            }
            return categoria;
        }

        public async Task<bool> DeleteAsync(Categoria entity)
        {
            bool result = false;
            var categoria = new Categoria();
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@CategoriaId", entity.CategoriaId);
            parameters.Add(p);

            var data = await _data.ExecuteProcedureAsync("SP_DeleteCategory", parameters);

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {

                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["Result"].ToString());
                //newProduct = await this.GetById(new Producto() { ProductoId = resultado });
            }
            return result;
            //throw new NotImplementedException();
        }
    }
}
