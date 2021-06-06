using System;

namespace Core.Models
{
    [Serializable]
    public class ShipPurchaseOrderDetailDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

    }
}
