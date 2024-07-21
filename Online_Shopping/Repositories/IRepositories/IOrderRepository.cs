﻿using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;

namespace Ecommerce.Api.Repositories.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}