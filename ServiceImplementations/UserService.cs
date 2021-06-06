using Core.Managers.ManagerInterfaces;
using Core.Managers.MangersImplementations;
using DataContracts;
using ServiceСontracts;
using System.Security.Claims;

namespace ServiceImplementations
{
    public class UserService : IUserService
    {
        IUserManager userManager = new UserManager();

        public OperationDetailsDTO Create(UserDTO userDto)
        {
            return userManager.Create(userDto);
        }
        public ClaimsIdentity Authenticate(UserDTO userDto)
        {
            return userManager.Authenticate(userDto);
        }
    }
}
