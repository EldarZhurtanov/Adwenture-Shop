using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string AddressLine1 { get; set; }
        [DataMember]
        public int AddressStateProvinceID { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}
