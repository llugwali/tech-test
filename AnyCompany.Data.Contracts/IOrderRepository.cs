﻿using AnyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Data.Contracts
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
