using Model.Models;
using System;

namespace Core.Managers.Helpers
{
    public static class PurchaseOrderDetailCreator
    {
        public static PurchaseOrderDetail Create(PurchaseOrderHeader orderHeader, ShoppingCartItem cartItem, Product product, ProductInventory productInventory, ProductReserve productReserve)
        {
            decimal receivedQty = cartItem.Quantity;
            decimal rejectedQty = 0;
            decimal productReserveQuantity = 0;

            if (productReserve != null && productReserve.Quantity.HasValue)
                productReserveQuantity = productReserve.Quantity.Value;

            if (cartItem.Quantity <= productInventory.Quantity - productReserveQuantity)
            {
                receivedQty = productInventory.Quantity - productReserveQuantity;
                rejectedQty = cartItem.Quantity - (productInventory.Quantity - productReserveQuantity);
            }
            return new PurchaseOrderDetail()
            {
                PurchaseOrderID = orderHeader.PurchaseOrderID,
                ProductID = product.ProductID,
                DueDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UnitPrice = product.StandardCost,
                OrderQty = Convert.ToInt16(cartItem.Quantity),
                ReceivedQty = receivedQty,
                RejectedQty = receivedQty,
                StockedQty = receivedQty - rejectedQty,
                LineTotal = receivedQty * product.StandardCost
            };
        }
    }
}
