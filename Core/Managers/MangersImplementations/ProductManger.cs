using Core.Managers.Helpers;
using Core.Managers.ManagerInterfaces;
using DataContracts;
using Model;
using Model.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.MangersImplementations
{
    public class ProductManger : IProductManager
    {
        private readonly DbContext context = new AdwentureWorksContext();
        private readonly UnitOfWork unitOfWork;

        public ProductManger()
        {
            unitOfWork = new UnitOfWork(context);
        }

        public DetailProductDTO GetDetailProduct(int productID)
        {
            var product = unitOfWork.Product.Get(productID);

            ProductModel productModel = null;
            ProductSubcategory subcategory = null;
            ProductDescription description = null;

            if(product.ProductSubcategoryID.HasValue)
                subcategory = unitOfWork.ProductSubcategory.Get(product.ProductSubcategoryID.Value);

            if (product.ProductModelID.HasValue)
            {
                productModel = unitOfWork.ProductModel.Get(product.ProductModelID.Value);

                var descriptiluonCulture = unitOfWork
                    .ProductModelProductDescriptionCulture
                    .GetList(a => a.ProductModelID == productModel.ProductModelID)
                    .FirstOrDefault();

                if (descriptiluonCulture != null)
                    description = unitOfWork.ProductDescription.Get(descriptiluonCulture.ProductDescriptionID);
            }

            var inventory = unitOfWork.ProductInventory.GetList(a => a.ProductID == productID).FirstOrDefault();
            var photosIDs = unitOfWork.ProductProductPhoto.GetList(a => a.ProductID == productID);

            return DetailProductDTOCreator.Create(product, photosIDs, inventory, description, subcategory);
        }

        public IEnumerable<ShortProductDTO> GetShortProducts(int skip, int take)
        {
            var shortProductDTOs = new List<ShortProductDTO>();
            var inStockProducts = new List<Product>();
            foreach (var product in unitOfWork.Product.GetList().OrderBy(a=> a.ProductID).Skip(skip).Take(take).ToList())
            {
                var inventory = unitOfWork
                                  .ProductInventory
                                  .GetList(a => a.ProductID == product.ProductID)
                                  .FirstOrDefault();

                if (inventory != null && inventory.Quantity > 0)
                    inStockProducts.Add(product);
            }
            
            foreach(var product in inStockProducts)
            {
                ProductSubcategory subcategory = null;

                if(product.ProductSubcategoryID.HasValue)
                    subcategory = unitOfWork.ProductSubcategory.Get(product.ProductSubcategoryID.Value);

                var inventory = unitOfWork.ProductInventory.GetList(a => a.ProductID == product.ProductID).FirstOrDefault();
                var thumbnail = unitOfWork.ProductProductPhoto.GetList(a => a.ProductID == product.ProductID).FirstOrDefault();

                shortProductDTOs.Add(ShortProductDTOCreator.Create(product, thumbnail, inventory, subcategory));
            }
            return shortProductDTOs;
        }
        public int GetProductsCount()
        {
            return unitOfWork.Product.GetList().Count();
        }

        public byte[] GetPhotoThumbnail(int id)
        {
            var thumbnail = unitOfWork.ProductPhoto.Get(id);

            if(thumbnail != null)
                return thumbnail.ThumbNailPhoto;

            return null;
        }

        public byte[] GetLargePhoto(int id)
        {
            var photo = unitOfWork.ProductPhoto.Get(id);

            if(photo != null)
                return photo.LargePhoto;
            return null;
        }
    }
}
