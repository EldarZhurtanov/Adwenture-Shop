using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.ManagerInterfaces
{
    public interface IProductManager
    {
        IEnumerable<ShortProductDTO> GetShortProducts(int skip, int take);
        DetailProductDTO GetDetailProduct(int productID);
        int GetProductsCount();
        byte[] GetPhotoThumbnail(int id); 
        byte[] GetLargePhoto(int id);
    }
}
