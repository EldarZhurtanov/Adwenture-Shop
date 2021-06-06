using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class PurchaseOrderDetailDTO
    {
        [DataMember]
        public IEnumerable<PurchaseOrderDetailRowDTO> PurchaseDetailRowDTOs { get; set; }
        [DataMember]
        public PurchaseOrdersHeaderDTO PurchaseOrdersDTO { get; set; }

    }
}
