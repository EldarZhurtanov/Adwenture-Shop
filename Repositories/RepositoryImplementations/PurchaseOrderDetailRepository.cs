using Model.Models;
using Repositories.RepositoryInterfaces;
using System.Data.Entity;

namespace Repositories.RepositoryImplementations
{
    public class PurchaseOrderDetailRepository : Repository<PurchaseOrderDetail>, IPurchaseOrderDetailRepository
    {
        public PurchaseOrderDetailRepository(DbContext context) : base(context)
        {
        }
    }
}
