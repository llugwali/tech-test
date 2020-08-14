using AnyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Business.Contracts
{
    public interface IOrderService
    {
        bool PlaceOrder(Order order, int customerId);
    }
}
