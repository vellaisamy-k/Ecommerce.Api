using Ecommerce.Api.AppDbContext;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;
using Ecommerce.Api.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Ecommerce.Api.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly EcommerceDbContext _context;

        public CustomerRepository(EcommerceDbContext context ) : base( context ) 
        {
                _context = context;
        }

        //public async Task Update(Customer customer)
        //{
        //    _context.Customer.Update( customer );
        //    await _context.SaveChangesAsync();
        //}
    }
}
