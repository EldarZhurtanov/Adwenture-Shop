using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class PurchaseOrdersHeaderDTO
    {
        [DataMember]
        public int PurchaseOrderID { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public int? EmployeeID { get; set; }
        [DataMember]
        public string EmployeeFullName { get; set; }
        [DataMember]
        public int ShipMethodID { get; set; }
        [DataMember]
        public string ShipMethodName { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public DateTime? ShipDate { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public decimal TaxAmt { get; set; }
        [DataMember]
        public decimal Freight { get; set; }
        [DataMember]
        public decimal TotalDue { get; set; }
    }
}
