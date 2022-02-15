using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessStored : IDataAccess
    {
        private readonly string _conexion;
        public DataAccessStored(string conexion)
        {
            _conexion = conexion;
        }

        public Task<DataSet> ExecuteProcedureAsync(string storedProcedure, List<SqlParameter> parametros)
        {
            return Task.Run(
                () =>
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        using (var innerConnection = new SqlConnection(_conexion))
                        {
                            using (SqlCommand cmd = innerConnection.CreateCommand())
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddRange(parametros.ToArray());
                                cmd.CommandText = storedProcedure;
                                cmd.CommandTimeout = int.MaxValue;

                                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                                sda.Fill(ds);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }

                    return ds;
                },System.Threading.CancellationToken.None);
        }
    }
}
