using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class AddressTypeRepository : Repository<AddressType>, IAddressTypeRepository
    {
        public AddressTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
