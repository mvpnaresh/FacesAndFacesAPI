using OrdersApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Business.Contract
{
    public interface IGetBusiness<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetByID(object id);
    }
}
