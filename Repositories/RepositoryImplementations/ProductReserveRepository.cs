using Model.Models;
using Repositories.RepositoryImplementations;
using System.Data.Entity;

namespace Repositories.RepositoryInterfaces
{
    public class ProductReserveRepository : Repository<ProductReserve>, IProductReserveRepository
    {
        public ProductReserveRepository(DbContext context) : base(context)
        {
        }
    }
}
