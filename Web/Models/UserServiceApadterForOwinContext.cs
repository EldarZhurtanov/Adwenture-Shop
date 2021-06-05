using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Web.UserServiceReference;

namespace Web.Models
{
    public class UserServiceApadterForOwinContext : UserServiceClient, IUserServiceApadterForOwinContext
    {
    }
}