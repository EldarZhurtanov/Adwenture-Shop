using DataContracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
