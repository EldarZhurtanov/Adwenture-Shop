using DataContracts;
using System.Collections.Generic;

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
