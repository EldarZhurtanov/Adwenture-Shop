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
