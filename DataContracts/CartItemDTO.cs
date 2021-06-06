using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class CartItemDTO
    {
        [DataMember]
        public int ShoppingCartItemID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
