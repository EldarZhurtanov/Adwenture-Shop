using DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceСontracts
{
    [ServiceContract]
    public interface IPurchaseOrderService
    {
        [OperationContract]
        IEnumerable<PurchaseOrdersHeaderDTO> GetPurchaseOrderHeadersDTO(PurchaseOrderFilterDTO purchaseOrderFilterDTO);
        [OperationContract]
        int GetCountOfPurchaseOrderHeaderDTOs(PurchaseOrderFilterDTO purchaseOrderFilterDTO);
        [OperationContract]
        PurchaseOrderDetailDTO GetPurchaseOrderDetailDTO(Guid orderGuidId);
        [OperationContract]
        PurchaseOrderDetailDTO Create(string cartId, string userId);
        [OperationContract]
        void Ship(Guid orderGuidId, string managerId);
        [OperationContract]
        void Close(Guid orderGuidId, string managerId);
    }
}
