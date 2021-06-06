using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
