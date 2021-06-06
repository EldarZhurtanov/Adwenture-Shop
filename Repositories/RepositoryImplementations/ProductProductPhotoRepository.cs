using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ProductProductPhotoRepository : Repository<ProductProductPhoto>, IProductProductPhotoRepository
    {
        public ProductProductPhotoRepository(DbContext context) : base(context)
        {
        }
    }
}
