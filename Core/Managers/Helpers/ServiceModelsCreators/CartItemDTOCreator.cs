using DataContracts;
using Model.Models;

namespace Core.Managers.Helpers
{
    public static class CartItemDTOCreator
    {
        public static CartItemDTO Create(ShoppingCartItem cartItem, Product product)
        {
            var newItem = new CartItemDTO();
            if (cartItem != null)
            {
                newItem.ShoppingCartItemID = cartItem.ShoppingCartItemID;
                newItem.SessionID = cartItem.ShoppingCartID;
                newItem.Quantity = cartItem.Quantity;
                newItem.ProductID = cartItem.ProductID;
                newItem.DateCreated = cartItem.DateCreated;
                newItem.ModifiedDate = cartItem.ModifiedDate;
            }
            if (product != null)
                newItem.ProductName = product.Name;

            return newItem;
        }
    }
}
