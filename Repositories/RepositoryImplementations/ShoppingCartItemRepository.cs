using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class ShoppingCartItemRepository : Repository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(DbContext context) : base(context)
        {
        }
    }
}
