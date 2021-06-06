using System;
using System.Collections.Generic;

namespace Core.Models
{
    [Serializable]
    public class ShipPurchaseOrderDTO
    {
        public int PurchaseOrderID { get; set; }
        public Guid PurchaseOrderGuid { get; set; }
        public decimal TotalDue { get; set; }
        public IEnumerable<ShipPurchaseOrderDetailDTO> PurchaseOrderDetails { get; set; }
        public ShipCustomerDTO Customer { get; set; }
    }
}
