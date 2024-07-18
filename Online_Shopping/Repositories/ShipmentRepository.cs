using Ecommerce.Api.AppDbContext;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.GenericRepository;
using Ecommerce.Api.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        private readonly EcommerceDbContext _context;

        public ShipmentRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

