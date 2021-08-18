using OrdersApi.DAL.Entities;
using OrdersApi.DAL.Repository.Interfaces;
using OrdersApi.DAL.Specifications.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApi.Business
{
    public abstract class BaseBusiness<T>  where T : BaseEntity
    {
        private readonly IUnitofWork<T> _uow;
        public BaseBusiness(IUnitofWork<T> uow)
        {
            _uow = uow;
        }

        public async virtual Task<IReadOnlyList<T>> GetAll()
        {
            return await _uow.Repository.ListAllAsync();
        }

        protected async virtual Task<T> GetByID(ISpecification<T> spec)
        {
            return await _uow.Repository.GetEntityWithSpec(spec);
        }
        
        public async virtual Task Update(T entityToUpdate)
        {
            await _uow.Repository.UpdateEntity(entityToUpdate);
            await _uow.Save();
        }

        public async virtual Task Add(T entity)
        {
            await _uow.Repository.AddEntity(entity);
            await _uow.Save();
        }
    }
}
