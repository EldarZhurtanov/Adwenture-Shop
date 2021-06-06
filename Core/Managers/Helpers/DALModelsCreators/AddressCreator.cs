using DataContracts;
using Model.Models;
using System;

namespace Core.Managers.Helpers
{
    public static class AddressCreator
    {
        public static Address CreateFromUserDTO(UserDTO userDTO)
        {
            return new Address()
            {
                AddressLine1 = userDTO.AddressLine1,
                StateProvinceID = userDTO.AddressStateProvinceID,
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid()
            };
        }
    }
}
