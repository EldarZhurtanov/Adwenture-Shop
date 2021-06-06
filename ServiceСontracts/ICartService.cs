using DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceСontracts
{
    [ServiceContract]
    public interface ICartService
    {
        [OperationContract]
        IEnumerable<CartItemDTO> GetCart(string sessionID);
        [OperationContract]
        void Delete(string sessionID);
        [OperationContract]
        void AddCartItem(string sessionID, int productID, int quantity);
        [OperationContract]
        void ChangeCartItemQuantity(string sessionID, int productID, int quantity);
    }
}
