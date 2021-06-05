using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;

namespace Model
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("AdwentureWorksContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AspNetUsersBusinesEntity> AspNetUsersBusinesEntitys { get; set; }
    }
}
