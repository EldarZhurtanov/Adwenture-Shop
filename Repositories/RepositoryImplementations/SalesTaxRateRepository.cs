using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class SalesTaxRateRepository : Repository<SalesTaxRate>, ISalesTaxRateRepository
    {
        public SalesTaxRateRepository(DbContext context) : base(context)
        {
        }
    }
}
