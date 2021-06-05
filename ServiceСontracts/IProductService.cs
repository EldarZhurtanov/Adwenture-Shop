using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
