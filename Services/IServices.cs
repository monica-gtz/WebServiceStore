using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServices<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetById(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        List<TEntity> Map(DataSet data);
    }
}