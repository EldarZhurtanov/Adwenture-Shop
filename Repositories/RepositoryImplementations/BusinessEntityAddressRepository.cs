using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class BusinessEntityAddressRepository : Repository<BusinessEntityAddress>, IBusinessEntityAddressRepository
    {
        public BusinessEntityAddressRepository(DbContext context) : base(context)
        {
        }
    }
}
