using DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Core.Managers.Helpers
{
    public static class InitialDataGetter
    {
        public static Tuple<UserDTO, List<string>> Get()
        {
            var userDTO = new UserDTO()
            {
                Email = ConfigurationManager.AppSettings.Get("Email"),
                UserName = ConfigurationManager.AppSettings.Get("UserName"),
                Password = ConfigurationManager.AppSettings.Get("Password"),
                FirstName = ConfigurationManager.AppSettings.Get("FirstName"),
                MiddleName = ConfigurationManager.AppSettings.Get("MiddleName"),
                LastName = ConfigurationManager.AppSettings.Get("LastName"),
                AddressLine1 = ConfigurationManager.AppSettings.Get("AddressLine1"),
                AddressStateProvinceID = Convert.ToInt32(ConfigurationManager.AppSettings.Get("AddressStateProvinceID")),
                Role = ConfigurationManager.AppSettings.Get("Role"),
            };
            var roles = new List<string>
            {
                ConfigurationManager.AppSettings.Get("Role1"),
                ConfigurationManager.AppSettings.Get("Role2"),
                ConfigurationManager.AppSettings.Get("Role3")
            };

            return new Tuple<UserDTO, List<string>>(userDTO, roles);
        }
    }
}
