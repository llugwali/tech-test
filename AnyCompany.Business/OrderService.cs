using AnyCompany.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Models;
using AnyCompany.Data.Contracts;

namespace AnyCompany.Business
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private ICustomerRepository _customerRepository;
        public OrderService(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;

        }
        public bool PlaceOrder(Order order, int customerId)
        {
            Customer customer = _customerRepository.Load(customerId);

            if (order.Amount == 0)
                return false;

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;

            _orderRepository.Save(order);

            return true;
        }
    }
}
