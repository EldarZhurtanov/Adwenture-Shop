using Model.Models;

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
