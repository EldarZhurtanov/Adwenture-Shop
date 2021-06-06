using DataContracts;
using System;
using System.Collections.Generic;

namespace Core.Managers.ManagerInterfaces
{
    interface IPurchaseOrderManager
    {
        IEnumerable<PurchaseOrdersHeaderDTO> GetPurchaseOrderHeadersDTO(PurchaseOrderFilterDTO purchaseOrderFilterDTO);
        int GetCountOfPurchaseOrderHeaderDTOs(PurchaseOrderFilterDTO purchaseOrderFilterDTO);
        PurchaseOrderDetailDTO GetPurchaseOrderDetailDTO(Guid orderGuidId);
        PurchaseOrderDetailDTO Create(string cartId, string userId);
        void Ship(Guid orderGuidId, string managerId);
        void Close(Guid orderGuidId, string managerId);

    }
}
