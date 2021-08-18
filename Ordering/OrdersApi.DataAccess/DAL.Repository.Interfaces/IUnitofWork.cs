using DAL.Repository.Interfaces;
using OrdersApi.DAL.Entities;
using System.Threading.Tasks;

namespace OrdersApi.DAL.Repository.Interfaces
{
    public interface IUnitofWork<TEntity> where TEntity : BaseEntity
    {
        IGenericRepository<TEntity> Repository { get; }

        Task Save();
    }
}
