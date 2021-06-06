using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}
