using DataContracts;
using System.Security.Claims;
using System.ServiceModel;

namespace ServiceСontracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        OperationDetailsDTO Create(UserDTO userDto);
        [OperationContract]
        ClaimsIdentity Authenticate(UserDTO userDto);
    }
}
