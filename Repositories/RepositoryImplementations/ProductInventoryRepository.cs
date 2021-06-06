using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ProductInventoryRepository : Repository<ProductInventory>, IProductInventoryRepository
    {
        public ProductInventoryRepository(DbContext context) : base(context)
        {
        }
    }
}
