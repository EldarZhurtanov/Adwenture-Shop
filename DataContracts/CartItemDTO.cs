using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
