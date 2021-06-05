using ServiceСontracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Managers.ManagerInterfaces;
using Core.Managers.MangersImplementations;
using DataContracts;
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
