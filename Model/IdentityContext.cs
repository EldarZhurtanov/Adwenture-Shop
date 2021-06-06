using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;
using System.Data.Entity;

namespace Model
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() : base("AdwentureWorksContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AspNetUsersBusinesEntity> AspNetUsersBusinesEntitys { get; set; }
    }
}
