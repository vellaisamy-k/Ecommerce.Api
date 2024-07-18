using Ecommerce.Api.AppDbContext;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;
using Ecommerce.Api.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly EcommerceDbContext _context;

        public PaymentRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
