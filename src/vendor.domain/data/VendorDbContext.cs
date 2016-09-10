using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vendor.domain.entities;

namespace vendor.domain.data
{

    public class VendorDbContext : IdentityDbContext<User, Role, long>
    {
        public VendorDbContext(DbContextOptions<VendorDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=local;Database=VendorDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity => entity.ToTable("Users"));
            builder.Entity<Role>(entity => entity.ToTable("Roles"));

        }

        public virtual DbSet<LanguageDict> LanguageDict { get; set; }
    }
}