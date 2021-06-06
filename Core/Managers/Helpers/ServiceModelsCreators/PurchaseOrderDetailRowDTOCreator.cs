using DataContracts;
using Model.Models;

namespace Core.Managers.Helpers
{
    public static class PurchaseOrderDetailRowDTOCreator
    {
        public static PurchaseOrderDetailRowDTO Create(PurchaseOrderDetail purchaseOrderDetail)
        {
            return new PurchaseOrderDetailRowDTO()
            {
                PurchaseOrderID = purchaseOrderDetail.PurchaseOrderID,
                ProductID = purchaseOrderDetail.ProductID,
                DueDate = purchaseOrderDetail.DueDate,
                StockedQty = purchaseOrderDetail.StockedQty,
                ModifiedDate = purchaseOrderDetail.ModifiedDate,
                PurchaseOrderDetailID = purchaseOrderDetail.PurchaseOrderDetailID,
                UnitPrice = purchaseOrderDetail.UnitPrice,
                LineTotal = purchaseOrderDetail.LineTotal,
                OrderQty = purchaseOrderDetail.OrderQty,
                ReceivedQty = purchaseOrderDetail.ReceivedQty,
                RejectedQty = purchaseOrderDetail.ReceivedQty
            };
        }
    }
}
