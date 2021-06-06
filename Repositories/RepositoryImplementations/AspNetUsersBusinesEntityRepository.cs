using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class AspNetUsersBusinesEntityRepository : Repository<AspNetUsersBusinesEntity>, IAspNetUsersBusinesEntityRepository
    {
        public AspNetUsersBusinesEntityRepository(DbContext context) : base(context)
        {
        }
    }
}
