using OrdersApi.Business.Contract;
using MassTransit;
using Messaging.Sharedlib.Events;
using Microsoft.AspNetCore.SignalR;
using OrdersApi.DAL.Entities;
using OrdersApi.Hubs;
using System;
using System.Threading.Tasks;

namespace OrdersApi.Messages.Consumers
{
    public class OrderDispatchedEventConsumer : IConsumer<IOrderDispatchedEvent>
    {
        private readonly IOrderBusiness _orderBusiness;
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderDispatchedEventConsumer(IOrderBusiness orderBusiness, IHubContext<OrderHub> hubContext)
        {
            _orderBusiness = orderBusiness;
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<IOrderDispatchedEvent> context)
        {
            var message = context.Message;
            Guid orderId = message.OrderId;
            await UpdateDatabase(orderId);
            await _hubContext.Clients.All.SendAsync("UpdateOrders", new object[] { "Order Dispatched", orderId });
        }

        private async Task UpdateDatabase(Guid orderId)
        {
            var order = await _orderBusiness.GetByID(orderId);
            if (order != null)
            {
                order.Status = Status.Sent;
                await _orderBusiness.Update(order);
            }
        }
    }
}
