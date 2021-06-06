using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;
using Repositories.IdentityManagers;
using Repositories.RepositoryImplementations;
using Repositories.RepositoryInterfaces;
using System;
using System.Data.Entity;

namespace Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _adwentureWorksContext;
        private readonly IdentityDbContext<ApplicationUser> _identityContext;

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
        public IProductModelRepository ProductModel { get; private set; }
        public IProductSubcategoryRepository ProductSubcategory { get; private set; }
        public IProductModelProductDescriptionCultureRepository ProductModelProductDescriptionCulture { get; private set; }
        public IAspNetUsersBusinesEntityRepository AspNetUsersBusinesEntity { get; private set; }
        public ApplicationUserManager ApplicationUser { get; private set; }
        public ApplicationRoleManager ApplicationRole { get; private set; }
        public IBusinessEntityAddressRepository BusinessEntityAddress { get; private set; }
        public IBusinessEntityRepository BusinessEntity { get; private set; }
        public IPersonRepository Person { get; private set; }
        public IAddressTypeRepository AddressType { get; private set; }
        public IStateProvinceRepository StateProvince { get; private set; }
        public ISalesTaxRateRepository SalesTaxRate { get; private set; }
        public IShipMethodRepository ShipMethod { get; private set; }
        public IProductReserveRepository ProductReserve { get; private set; }


        public UnitOfWork(DbContext adwentureWorkContext, IdentityDbContext<ApplicationUser> identityDbContext)
        {
            _adwentureWorksContext = adwentureWorkContext;
            _identityContext = identityDbContext;

            Address = new AddressRepository(adwentureWorkContext);
            Customer = new CustomerRepository(adwentureWorkContext);
            ProductDescription = new ProductDescriptionRepository(adwentureWorkContext);
            ProductInventory = new ProductInventoryRepository(adwentureWorkContext);
            ProductPhoto = new ProductPhotoRepository(adwentureWorkContext);
            ProductProductPhoto = new ProductProductPhotoRepository(adwentureWorkContext);
            Product = new ProductRepository(adwentureWorkContext);
            PurchaseOrderDetail = new PurchaseOrderDetailRepository(adwentureWorkContext);
            PurchaseOrderHeader = new PurchaseOrderHeaderRepository(adwentureWorkContext);
            SalesPerson = new SalesPersonRepository(adwentureWorkContext);
            SalesTerritory = new SalesTerritoryRepository(adwentureWorkContext);
            ShoppingCart = new ShoppingCartItemRepository(adwentureWorkContext);
            ProductModel = new ProductModelRepository(adwentureWorkContext);
            ProductSubcategory = new ProductSubcategoryRepository(adwentureWorkContext);
            ProductModelProductDescriptionCulture = new ProductModelProductDescriptionCultureRepository(adwentureWorkContext);
            AspNetUsersBusinesEntity = new AspNetUsersBusinesEntityRepository(_identityContext);
            ApplicationUser = new ApplicationUserManager(new UserStore<ApplicationUser>(_identityContext));
            ApplicationRole = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_identityContext));
            BusinessEntityAddress = new BusinessEntityAddressRepository(adwentureWorkContext);
            BusinessEntity = new BusinessEntityRepository(adwentureWorkContext);
            Person = new PersonRepository(adwentureWorkContext);
            AddressType = new AddressTypeRepository(adwentureWorkContext);
            StateProvince = new StateProvinceRepository(adwentureWorkContext);
            SalesTaxRate = new SalesTaxRateRepository(adwentureWorkContext);
            ShipMethod = new ShipMethodRepository(adwentureWorkContext);
            ProductReserve = new ProductReserveRepository(adwentureWorkContext);
        }

        public int Complete()
        {
            return _adwentureWorksContext.SaveChanges();
        }
        public void Dispose()
        {
            _adwentureWorksContext.Dispose();
        }
    }
}
