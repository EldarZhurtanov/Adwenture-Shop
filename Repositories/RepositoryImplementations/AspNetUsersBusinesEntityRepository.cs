using Model;
using Model.Models;
using Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoryImplementations
{
    public class AspNetUsersBusinesEntityRepository : Repository<AspNetUsersBusinesEntity>, IAspNetUsersBusinesEntityRepository
    {
        public AspNetUsersBusinesEntityRepository(DbContext context) : base(context)
        {
        }
    }
}
