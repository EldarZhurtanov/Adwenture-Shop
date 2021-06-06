using System;

namespace Core.Models
{
    [Serializable]
    public class ShipCustomerDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
    }
}
