using OrdersApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Business.Contract
{
    public interface ISetBusiness<T> where T : BaseEntity
    {
        Task Add(T entity);
  
        Task Update(T entityToUpdate);
    }
}
