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
    public class SalesTerritoryRepository : Repository<SalesTerritory>, ISalesTerritoryRepository
    {
        public SalesTerritoryRepository(DbContext context) : base(context)
        {
        }
    }
}
