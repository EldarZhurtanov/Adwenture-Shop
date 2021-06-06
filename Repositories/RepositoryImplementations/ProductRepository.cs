using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
