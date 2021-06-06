using DataContracts;
using System.Collections.Generic;

namespace Core.Managers.ManagerInterfaces
{
    public interface ICartManager
    {
        IEnumerable<CartItemDTO> GetCart(string sessionID);
        void Delete(string sessionID);
        void AddCartItem(string sessionID, int productID, int quantity);
        void ChangeCartItemQuantity(string sessionID, int productID, int quantity);

    }
}
