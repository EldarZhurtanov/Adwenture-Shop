using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
