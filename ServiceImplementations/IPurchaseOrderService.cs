using Core.Managers.MangersImplementations;
using DataContracts;
using ServiceСontracts;
using System;
using System.Collections.Generic;

namespace ServiceImplementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        readonly PurchaseOrderManager productManager = new PurchaseOrderManager();

        public void Close(Guid orderGuidId, string managerId)
        {
            productManager.Close(orderGuidId, managerId);
        }

        public PurchaseOrderDetailDTO Create(string cartId, string userId)
        {
            return productManager.Create(cartId, userId);
        }

        public int GetCountOfPurchaseOrderHeaderDTOs(PurchaseOrderFilterDTO purchaseOrderFilterDTO)
        {
            return productManager.GetCountOfPurchaseOrderHeaderDTOs(purchaseOrderFilterDTO);
        }

        public PurchaseOrderDetailDTO GetPurchaseOrderDetailDTO(Guid orderGuidId)
        {
            return productManager.GetPurchaseOrderDetailDTO(orderGuidId);
        }

        public IEnumerable<PurchaseOrdersHeaderDTO> GetPurchaseOrderHeadersDTO(PurchaseOrderFilterDTO purchaseOrderFilterDTO)
        {
            return productManager.GetPurchaseOrderHeadersDTO(purchaseOrderFilterDTO);
        }

        public void Ship(Guid orderGuidId, string managerId)
        {
            productManager.Ship(orderGuidId, managerId);
        }
    }
}
