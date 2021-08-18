using OrdersApi.Business.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderBusiness _orderBusiness;
        public OrdersController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _orderBusiness.GetAll();
            return Ok(data);
        }

        [HttpGet]
        [Route("{orderId}", Name = "GetOrderById")]
        public async Task<IActionResult> GetOrderById(string orderId)
        {

            var order = await _orderBusiness.GetByID(Guid.Parse(orderId));
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
