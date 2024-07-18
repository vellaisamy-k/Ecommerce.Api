using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;

namespace Ecommerce.Api.Repositories.IRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        //Task Update(Customer customer);
    }
}
