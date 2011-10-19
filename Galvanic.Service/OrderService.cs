using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Galvanic.Model;
using Galvanic.Infrastructure;
using Galvanic.Data;
using Galvanic.Service.Interface;

namespace Galvanic.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }
    }
}
