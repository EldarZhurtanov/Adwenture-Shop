using Model.Models;
using Repositories.RepositoryImplementations;
using System.Data.Entity;

namespace Repositories.RepositoryInterfaces
{
    public class ProductSubcategoryRepository : Repository<ProductSubcategory>, IProductSubcategoryRepository
    {
        public ProductSubcategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
