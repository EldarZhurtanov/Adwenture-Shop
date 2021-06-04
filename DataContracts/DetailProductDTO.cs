using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Core.Models
{
    [DataContract]
    public class DetailProductDTO
    {
        [DataMember]
        public int? ProductID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ProductNumber { get; set; }
        [DataMember]
        public decimal? StandardCost { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public IEnumerable<int> LargePhotosIDs { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public short? Quantity { get; set; }
        [DataMember]
        public string SubcategoryName { get; set; }
    }
}