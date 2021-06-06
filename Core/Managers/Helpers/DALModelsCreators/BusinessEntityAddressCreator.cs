using Model.Models;
using System;

namespace Core.Managers.Helpers
{
    public static class BusinessEntityAddressCreator
    {
        public static BusinessEntityAddress Create(BusinessEntity businessEntity, Address address, AddressType addressType)
        {
            return new BusinessEntityAddress()
            {
                BusinessEntityID = businessEntity.BusinessEntityID,
                AddressID = address.AddressID,
                AddressTypeID = addressType.AddressTypeID,
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid()
            };
        }
    }
}
