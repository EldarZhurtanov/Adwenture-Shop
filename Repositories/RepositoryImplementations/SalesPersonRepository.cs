using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class SalesPersonRepository : Repository<SalesPerson>, ISalesPersonRepository
    {
        public SalesPersonRepository(DbContext context) : base(context)
        {
        }
    }
}
