using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ProductDescriptionRepository : Repository<ProductDescription>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(DbContext context) : base(context)
        {
        }
    }
}
