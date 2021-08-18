using DAL.Repository.Interfaces;
using DAL.Repository.SpecificationEvaluator;
using OrdersApi.DAL.Specifications.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrdersApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        internal DbContext _dbContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }

        public async Task UpdateEntity(T entity)
        {
            void modifyAction()
            {
                _dbContext.Entry<T>(entity).State = EntityState.Modified;
            }
            await Task.Run(modifyAction);
        }

        public async Task AddEntity(T entity)
        {
            await _dbContext.AddAsync<T>(entity);
        }

    }
}
