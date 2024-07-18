using Ecommerce.Api.AppDbContext;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;
using Ecommerce.Api.Repositories.IRepository;

namespace Ecommerce.Api.Repositories
{
    public class CartRepository :  GenericRepository<Cart>, ICartRepository
    {
        private readonly EcommerceDbContext _context;

        public CartRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
