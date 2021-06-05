using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class StateProvinceRepository : Repository<StateProvince>, IStateProvinceRepository
    {
        public StateProvinceRepository(DbContext context) : base(context)
        {
        }
    }
}
