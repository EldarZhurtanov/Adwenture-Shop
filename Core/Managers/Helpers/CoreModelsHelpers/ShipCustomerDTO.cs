using Core.Models;
using Model.Models;

namespace Core.Managers.Helpers.CoreModelsHelpers
{
    public static class ShipCustomerDTOCreator
    {
        public static ShipCustomerDTO Create(Person person, Address address, string Email)
        {
            return new ShipCustomerDTO()
            {
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                Email = Email,
                AddressLine1 = address.AddressLine1
            };
        }
    }
}
