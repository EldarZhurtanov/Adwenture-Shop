using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;

namespace Repositories.IdentityManagers
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store) : base(store)
        {

        }
    }
}
