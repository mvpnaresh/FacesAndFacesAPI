using OrdersApi.Business.Contract;
using OrdersApi.DAL.Entities;
using OrdersApi.DAL.Repository.Interfaces;
using OrdersApi.DAL.Repository.Specifications;
using System.Threading.Tasks;

namespace OrdersApi.Business
{
    public class OrderBusiness : BaseBusiness<Order>, IOrderBusiness
    {
        public OrderBusiness(IUnitofWork<Order> uow)
           : base(uow)
        {

        }

        public async Task<Order> GetByID(object id)
        {
            var spec = new OrdersWithDetailsSpecification(id);
            return await base.GetByID(spec);
        }
    }
}
