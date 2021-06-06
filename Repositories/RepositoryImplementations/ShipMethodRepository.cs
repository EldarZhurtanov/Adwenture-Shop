using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ShipMethodRepository : Repository<ShipMethod>, IShipMethodRepository
    {
        public ShipMethodRepository(DbContext context) : base(context)
        {
        }
    }
}
