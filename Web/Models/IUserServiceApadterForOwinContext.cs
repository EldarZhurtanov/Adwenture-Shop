using System;
using Web.UserServiceReference;

namespace Web.Models
{
    public interface IUserServiceApadterForOwinContext : IUserService, IDisposable
    {
    }
}
