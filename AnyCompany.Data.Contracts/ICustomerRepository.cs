using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Models;

namespace AnyCompany.Data.Contracts
{
    public interface ICustomerRepository
    {
        Customer Load(int customerId);
    }
}
