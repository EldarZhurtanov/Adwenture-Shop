using Core.Managers.Helpers;
using Core.Managers.ManagerInterfaces;
using DataContracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Model.Models;
using Repositories;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

namespace Core.Managers.MangersImplementations
{
    public class UserManager : IUserManager
    {
        private readonly DbContext context = new AdwentureWorksContext();
        private readonly IdentityDbContext<ApplicationUser> identityDbContext = new IdentityContext();
        private readonly UnitOfWork unitOfWork;

        public UserManager()
        {
            unitOfWork = new UnitOfWork(context, identityDbContext);

            var initiaData = InitialDataGetter.Get();
            SetInitialData(initiaData.Item1, initiaData.Item2);
        }

        public OperationDetailsDTO Create(UserDTO userDto)
        {

            var userExist = unitOfWork.ApplicationUser.FindByEmail(userDto.Email) != null;

            if (userExist)
                return new OperationDetailsDTO(false, "AlreadyExist", "Email");

            var applicationUser = ApplicationUserCreator.CreateFromUserDTO(userDto);

            var a = unitOfWork.ApplicationUser.Create(applicationUser, userDto.Password);
            unitOfWork.ApplicationUser.AddToRole(applicationUser.Id, userDto.Role);

            var businessEntity = unitOfWork.BusinessEntity.Create(BusinessEntityCreator.Create());
            unitOfWork.Complete();

            var address = unitOfWork.Address.Create(AddressCreator.CreateFromUserDTO(userDto));
            unitOfWork.Complete();

            var stateProvince = unitOfWork.StateProvince.Get(address.StateProvinceID);
            var addressTypeName = ConfigurationManager.AppSettings.Get("AddressTypeName");
            var addressType = unitOfWork.AddressType.GetList(e => e.Name == addressTypeName).FirstOrDefault();
            var businessEntityAddress = unitOfWork.BusinessEntityAddress.Create(BusinessEntityAddressCreator.Create(businessEntity, address, addressType));
            unitOfWork.Complete();

            var aspNetUsersBusinesEntity = unitOfWork.AspNetUsersBusinesEntity.Create(AspNetUsersBusinesEntityCreator.Create(applicationUser, businessEntity));
            unitOfWork.Complete();

            var person = unitOfWork.Person.Create(PersonCreator.Create(businessEntity, userDto));
            unitOfWork.Complete();

            var customer = unitOfWork.Customer.Create(CustomerCreator.Create(person, stateProvince));
            unitOfWork.Complete();

            return new OperationDetailsDTO(true, string.Empty, string.Empty);
        }

        public ClaimsIdentity Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;

            ApplicationUser user = unitOfWork.ApplicationUser.Find(userDto.Email, userDto.Password);

            if (user != null)
                claim = unitOfWork.ApplicationUser.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            return claim;
        }
        private void SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = unitOfWork.ApplicationRole.FindByName(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    unitOfWork.ApplicationRole.CreateAsync(role);
                }
            }

            Create(adminDto);
        }
    }
}
