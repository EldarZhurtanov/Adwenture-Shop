using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ProductModelRepository : Repository<ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(DbContext context) : base(context)
        {
        }
    }
}
