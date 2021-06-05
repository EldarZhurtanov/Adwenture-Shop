using Microsoft.AspNet.Identity;
using Model.Models;

namespace Repositories.IdentityManagers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }
    }
}
