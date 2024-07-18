using Ecommerce.Api.AppDbContext;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;
using Ecommerce.Api.Repositories.IRepository;

namespace Ecommerce.Api.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly EcommerceDbContext _context;

        public OrderRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
