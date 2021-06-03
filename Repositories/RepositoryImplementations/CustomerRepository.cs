using Model;
using Model.Models;
using Repositories.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoryInterfaces
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
