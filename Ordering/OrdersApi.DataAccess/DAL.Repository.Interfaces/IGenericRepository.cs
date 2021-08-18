using OrdersApi.DAL.Specifications.Interfaces;
using OrdersApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task UpdateEntity(T entity);
        Task AddEntity(T entity);

    }
}
