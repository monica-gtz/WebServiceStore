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
    public class EstatusServices : IServices<Estatus>
    {
        IDataAccess _data;

        public EstatusServices(IDataAccess data)
        {
            _data = data;
        }


        public async Task<List<Estatus>> GetAllAsync()
        {
            var parametros = new List<SqlParameter>();
            var data = await _data.ExecuteProcedureAsync("SP_GetAllEstatus", parametros);

            return Map(data);
        }

        public async Task<Estatus> AddAsync(Estatus newEstatus)
        {
            var estatus = new Estatus();
            var parameters = new List<SqlParameter>();

            var p = new SqlParameter("@Description", newEstatus.Description);
            parameters.Add(p);

            var data = await _data.ExecuteProcedureAsync("SP_AddEstatus", parameters);

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                //Si to do sale correctamente se pone el 1 como resultado
                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["CategoriaId"].ToString());
                estatus = await this.GetById(new Estatus() { EstatusId = resultado });
            }

            return estatus;
        }

        public async Task<Estatus> GetById(Estatus estatusId)
        {
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@EstatusId", estatusId.EstatusId);
            parameters.Add(p);
            var data = await _data.ExecuteProcedureAsync("SP_GetEstatusById", parameters);

            return Map(data)[0];
        }

        public async Task<Estatus> UpdateAsync(Estatus estatus)
        {
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@EstatusId", estatus.EstatusId);
            parameters.Add(p);
            p = new SqlParameter("@Description", estatus.Description);
            parameters.Add(p);
            

            var data = await _data.ExecuteProcedureAsync("SP_EditEstatus", parameters);

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                //Si todo sale correctamente se pone el 1 como resultado
                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["Result"].ToString());
                //product = await this.GetById(new Producto() { ProductoId = resultado });
            }
            return estatus;
        }

        public async Task<bool> DeleteAsync(Estatus entity)
        {
            bool result = false;
            var estatus = new Estatus();
            var parameters = new List<SqlParameter>();
            var p = new SqlParameter("@EstatusId", entity.EstatusId);
            parameters.Add(p);

            var data = await _data.ExecuteProcedureAsync("SP_DeleteEstatus", parameters);

            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {

                DataRow registro = data.Tables[0].Rows[0];
                var resultado = int.Parse(registro["Result"].ToString());
                //newProduct = await this.GetById(new Producto() { ProductoId = resultado });
            }
            return result;
        }

        public List<Estatus> Map(DataSet data)
        {
            List<Estatus> resultados = new List<Estatus>();
            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                resultados.AddRange(data.Tables[0]
                    .Rows.Cast<DataRow>()
                    .Select(registro => new Estatus
                    {
                        EstatusId = int.Parse(registro["EstatusId"].ToString()),
                        Description = registro["Description"].ToString(),
                        

                    }));

            }
            return resultados;
        }
    }
}
