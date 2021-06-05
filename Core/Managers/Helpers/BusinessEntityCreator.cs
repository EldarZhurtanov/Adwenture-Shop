using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.Helpers
{
    public static class BusinessEntityCreator
    {
        public static BusinessEntity Create()
        {
            return new BusinessEntity() 
            { 
                ModifiedDate = System.DateTime.Now,
                rowguid = Guid.NewGuid()
            };
        }
    }
}
