using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {
        }
    }
}
