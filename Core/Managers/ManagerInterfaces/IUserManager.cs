using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.ManagerInterfaces
{
    public interface IUserManager
    {
        OperationDetailsDTO Create(UserDTO userDto);
        ClaimsIdentity Authenticate(UserDTO userDto);
    }
}
