using Repositories.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _context;

        public PurchaseOrderHeaderRepository PurchaseOrderHeaderRepository { get; private set; }

        public UnitOfWork(DbContext context)
        {
            this._context = context;

            PurchaseOrderHeaderRepository = new PurchaseOrderHeaderRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
