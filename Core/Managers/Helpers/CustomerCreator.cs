using DataContracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.Helpers
{
    public static class CustomerCreator
    {
        public static Customer Create(Person person, StateProvince stateProvince)
        {
            return new Customer() 
            { 
                PersonID = person.BusinessEntityID,
                TerritoryID = stateProvince.TerritoryID,
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid()
            };
        }
    }
}
