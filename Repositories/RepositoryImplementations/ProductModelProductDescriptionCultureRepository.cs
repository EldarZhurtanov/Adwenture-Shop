using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ProductModelProductDescriptionCultureRepository : Repository<ProductModelProductDescriptionCulture>, IProductModelProductDescriptionCultureRepository
    {
        public ProductModelProductDescriptionCultureRepository(DbContext context) : base(context)
        {
        }
    }
}
