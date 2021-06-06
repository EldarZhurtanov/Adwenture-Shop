using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class BusinessEntityRepository : Repository<BusinessEntity>, IBusinessEntityRepository
    {
        public BusinessEntityRepository(DbContext context) : base(context)
        {
        }
    }
}
