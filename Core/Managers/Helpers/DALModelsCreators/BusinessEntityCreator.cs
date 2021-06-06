using Model.Models;
using System;

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
