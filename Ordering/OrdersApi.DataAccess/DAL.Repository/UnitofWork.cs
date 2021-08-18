using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrdersApi.DAL.Entities;
using OrdersApi.DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrdersApi.DAL.Repository
{
    public class UnitofWork<TEntity> : IDisposable, IUnitofWork<TEntity> where TEntity : BaseEntity
    {
        internal DbContext _context;
        public IGenericRepository<TEntity> Repository
        {
            get;
        }

        public UnitofWork(DbContext context, IGenericRepository<TEntity> repository)
        {
            _context = context;
            Repository = repository;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #region "IDisposable"
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {

                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
