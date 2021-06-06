using DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceСontracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<ShortProductDTO> GetShortProducts(int skip, int take);
        [OperationContract]
        DetailProductDTO GetDetailProduct(int productID);
        [OperationContract]
        int GetProductsCount();
        [OperationContract]
        byte[] GetPhotoThumbnail(int id);
        [OperationContract]
        byte[] GetLargePhoto(int id);

    }
}
