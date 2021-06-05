using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Model.Models;
using Repositories.IdentityManagers;
using Repositories.RepositoryImplementations;
using Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Types;
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
        public AspNetUsersBusinesEntityRepository AspNetUsersBusinesEntity { get; private set; }
        public ApplicationUserManager ApplicationUser { get; private set; }
        public ApplicationRoleManager ApplicationRole { get; private set; }
        public BusinessEntityAddressRepository BusinessEntityAddress { get; private set; }
        public BusinessEntityRepository BusinessEntity { get; private set; }
        public PersonRepository Person { get; private set; }
        public AddressTypeRepository AddressType { get; private set; }
        public StateProvinceRepository StateProvince { get; private set; }

        public UnitOfWork(DbContext context)
        {
            this._context = context;
            var v = new ApplicationContext();

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
            AspNetUsersBusinesEntity = new AspNetUsersBusinesEntityRepository(v);
            ApplicationUser = new ApplicationUserManager(new UserStore<ApplicationUser>(v));
            ApplicationRole = new ApplicationRoleManager(new RoleStore<ApplicationRole>(v));
            BusinessEntityAddress = new BusinessEntityAddressRepository(context);
            BusinessEntity = new BusinessEntityRepository(context);
            Person = new PersonRepository(context);
            AddressType = new AddressTypeRepository(context);
            StateProvince = new StateProvinceRepository(context);
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
