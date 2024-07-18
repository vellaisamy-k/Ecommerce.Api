using Ecommerce.Api.AppDbContext;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;
using Ecommerce.Api.Repositories.IRepository;

namespace Ecommerce.Api.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly EcommerceDbContext _context;

        public OrderItemRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
