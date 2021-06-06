using DataContracts;
using System.Security.Claims;

namespace Core.Managers.ManagerInterfaces
{
    public interface IUserManager
    {
        OperationDetailsDTO Create(UserDTO userDto);
        ClaimsIdentity Authenticate(UserDTO userDto);
    }
}
