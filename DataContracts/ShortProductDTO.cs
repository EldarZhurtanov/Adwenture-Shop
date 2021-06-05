using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class ShortProductDTO
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
        public int ThumbNailPhotoID { get; set; }
        [DataMember]
        public short? Quantity { get; set; }
        [DataMember]
        public string SubcategoryName { get; set; }
    }
}