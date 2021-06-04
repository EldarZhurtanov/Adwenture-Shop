using Repositories.RepositoryImplementations;
using Repositories.RepositoryInterfaces;
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

        public IAddressRepository Address { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IProductDescriptionRepository ProductDescription { get; private set; }
        public IProductInventoryRepository ProductInventory { get; private set; }
        public IProductPhotoRepository ProductPhoto { get; private set; }
        public IProductProductPhotoRepository ProductProductPhoto { get; private set; }
        public IProductRepository Product { get; private set; }
        public IPurchaseOrderDetailRepository PurchaseOrderDetail { get; private set; }
        public IPurchaseOrderHeaderRepository PurchaseOrderHeader { get; private set; }
        public ISalesPersonRepository SalesPerson { get; private set; }
        public ISalesTerritoryRepository SalesTerritory { get; private set; }
        public IShoppingCartItemRepository ShoppingCart { get; private set; }
        public ProductModelRepository ProductModel { get; private set; }
        public ProductSubcategoryRepository  ProductSubcategory { get; private set; }
        public ProductModelProductDescriptionCultureRepository ProductModelProductDescriptionCulture { get; private set; }

        public UnitOfWork(DbContext context)
        {
            this._context = context;

            Address = new AddressRepository(context);
            Customer = new CustomerRepository(context);
            ProductDescription = new ProductDescriptionRepository(context);
            ProductInventory = new ProductInventoryRepository(context);
            ProductPhoto = new ProductPhotoRepository(context);
            ProductProductPhoto = new ProductProductPhotoRepository(context);
            Product = new ProductRepository(context);
            PurchaseOrderDetail = new PurchaseOrderDetailRepository(context);
            PurchaseOrderHeader = new PurchaseOrderHeaderRepository(context);
            SalesPerson = new SalesPersonRepository(context);
            SalesTerritory = new SalesTerritoryRepository(context);
            ShoppingCart = new ShoppingCartItemRepository(context);
            ProductModel = new ProductModelRepository(context);
            ProductSubcategory = new ProductSubcategoryRepository(context);
            ProductModelProductDescriptionCulture = new ProductModelProductDescriptionCultureRepository(context);
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
