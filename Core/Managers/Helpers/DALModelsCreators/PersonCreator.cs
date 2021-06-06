using DataContracts;
using Model.Models;
using System;
using System.Configuration;

namespace Core.Managers.Helpers
{
    public static class PersonCreator
    {
        public static Person Create(BusinessEntity businessEntity, UserDTO userDTO)
        {
            return new Person()
            {
                BusinessEntityID = businessEntity.BusinessEntityID,
                FirstName = userDTO.FirstName,
                MiddleName = userDTO.MiddleName,
                LastName = userDTO.LastName,
                PersonType = ConfigurationManager.AppSettings.Get("PersonType"),
                NameStyle = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("NameStyle")),
                EmailPromotion = Convert.ToInt32(ConfigurationManager.AppSettings.Get("EmailPromotion")),
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid()
            };
        }
    }
}
