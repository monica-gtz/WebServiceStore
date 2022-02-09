using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess
    {
        Task<DataSet> ExecuteProcedureAsync(string storedProcedure, List<SqlParameter> parametros);
    }    
}
