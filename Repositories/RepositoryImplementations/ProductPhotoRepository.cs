using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ProductPhotoRepository : Repository<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(DbContext context) : base(context)
        {
        }
    }
}
