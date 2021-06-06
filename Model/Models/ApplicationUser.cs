using Microsoft.AspNet.Identity.EntityFramework;

namespace Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual AspNetUsersBusinesEntity AspNetUsersBusinesEntity { get; set; }
    }
}
