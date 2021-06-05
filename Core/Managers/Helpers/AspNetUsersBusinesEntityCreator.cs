using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.Helpers
{
    public static class AspNetUsersBusinesEntityCreator
    {
        public static AspNetUsersBusinesEntity Create(ApplicationUser applicationUser, BusinessEntity businessEntity)
        {
            return new AspNetUsersBusinesEntity() 
            { 
                Id = applicationUser.Id,
                BusinessEntityID = businessEntity.BusinessEntityID,
            };
        }
    }
}
