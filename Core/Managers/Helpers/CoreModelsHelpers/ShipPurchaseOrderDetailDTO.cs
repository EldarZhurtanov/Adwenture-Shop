using Core.Models;
using Model.Models;
using System;

namespace Core.Managers.Helpers.CoreModelsHelpers
{
    public static class ShipPurchaseOrderDetailDTOCreator
    {
        public static ShipPurchaseOrderDetailDTO Create(Product product, PurchaseOrderDetail purchaseOrderDetail)
        {
            return new ShipPurchaseOrderDetailDTO()
            {
                ProductID = product.ProductID,
                ProductName = product.Name,
                Quantity = Convert.ToInt32(purchaseOrderDetail.ReceivedQty)
            };
        }
    }
}
