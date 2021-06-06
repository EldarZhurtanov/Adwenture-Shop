using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class PurchaseOrderFilterDTO
    {
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserRole { get; set; }
        [DataMember]
        public int Skip { get; set; }
        [DataMember]
        public int Take { get; set; }
    }
}
