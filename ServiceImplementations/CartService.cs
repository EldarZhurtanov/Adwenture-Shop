using Core.Managers.ManagerInterfaces;
using Core.Managers.MangersImplementations;
using DataContracts;
using ServiceСontracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementations
{
    public class CartService : ICartService
    {
        ICartManager productManager = new CartManager();
        public void AddCartItem(string sessionID, int productID, int quantity)
        {
            productManager.AddCartItem(sessionID, productID, quantity);
        }

        public void ChangeCartItemQuantity(string sessionID, int productID, int quantity)
        {
            productManager.ChangeCartItemQuantity(sessionID, productID, quantity);
        }

        public void Delete(string sessionID)
        {
            productManager.Delete(sessionID);
        }

        public IEnumerable<CartItemDTO> GetCart(string sessionID)
        {
            return productManager.GetCart(sessionID);
        }
    }
}
