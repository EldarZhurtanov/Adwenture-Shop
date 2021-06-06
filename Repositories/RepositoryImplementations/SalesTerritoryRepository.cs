using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class SalesTerritoryRepository : Repository<SalesTerritory>, ISalesTerritoryRepository
    {
        public SalesTerritoryRepository(DbContext context) : base(context)
        {
        }
    }
}
