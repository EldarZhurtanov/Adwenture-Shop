using Core.Models;
using ServiceСontracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Managers.ManagerInterfaces;
using Core.Managers.MangersImplementations;

namespace ServiceImplementations
{
    public class ProductService : IProductService
    {
        IProductManager productManager = new ProductManger();
        public DetailProductDTO GetDetailProduct(int productID)
        {
            return productManager.GetDetailProduct(productID);
        }
        public IEnumerable<ShortProductDTO> GetShortProducts(int skip, int take)
        {
            return productManager.GetShortProducts(skip, take);
        }
        public int GetProductsCount()
        {
            return productManager.GetProductsCount();
        }

        public byte[] GetPhotoThumbnail(int id)
        {
            return productManager.GetPhotoThumbnail(id);
        }

        public byte[] GetLargePhoto(int id)
        {
            return productManager.GetLargePhoto(id);
        }
    }
}
