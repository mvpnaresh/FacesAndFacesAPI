
using OrdersApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.DAL.Repository.Specifications
{
    public class OrdersWithDetailsSpecification : BaseSpecification<Order>
    {
        public OrdersWithDetailsSpecification()
        {
            AddInclude(x => x.OrderDetails);
        }

        public OrdersWithDetailsSpecification(object id)
            : base(x => x.OrderId == Guid.Parse(id.ToString()))
        {
            AddInclude(x => x.OrderDetails);
        }
    }
}
