using Core.Models;
using Model.Models;
using System.Collections.Generic;

namespace Core.Managers.Helpers.CoreModelsHelpers
{
    public static class ShipPurchaseOrderDTOCreator
    {
        public static ShipPurchaseOrderDTO Create(PurchaseOrderHeader purchaseOrderHeader
            , IEnumerable<ShipPurchaseOrderDetailDTO> detailDTOs, ShipCustomerDTO customerDTO)
        {
            return new ShipPurchaseOrderDTO()
            {
                PurchaseOrderID = purchaseOrderHeader.PurchaseOrderID,
                PurchaseOrderGuid = purchaseOrderHeader.rowguid.Value,
                TotalDue = purchaseOrderHeader.TotalDue,
                PurchaseOrderDetails = detailDTOs,
                Customer = customerDTO
            };
        }
    }
}
