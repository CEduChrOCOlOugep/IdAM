using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdAM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<App> Apps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Many-to-many relationship between ApplicationUser and App
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Apps)
                .WithMany(a => a.Users)
                .UsingEntity(j => j.ToTable("UserApplications"));

            // Many-to-many relationship between ApplicationRole and App
            builder.Entity<ApplicationRole>()
                .HasMany(r => r.Apps)
                .WithMany(a => a.Roles)
                .UsingEntity(j => j.ToTable("AppRoles"));

            // Configuring ApplicationUser for cascade delete on roles and claims
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.Id).HasColumnType("nvarchar(450)");
                entity.HasMany(p => p.Roles)
                      .WithOne()
                      .HasForeignKey(p => p.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Claims)
                      .WithOne()
                      .HasForeignKey(e => e.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuring ApplicationRole for cascade delete on role claims
            builder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(r => r.Id).HasColumnType("nvarchar(450)");
                entity.HasMany(r => r.Claims)
                      .WithOne()
                      .HasForeignKey(r => r.RoleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuring App for many-to-many relationships with ApplicationUser and ApplicationRole
            builder.Entity<App>(entity =>
            {
                entity.HasMany(a => a.Users)
                      .WithMany(u => u.Apps)
                      .UsingEntity(j => j.ToTable("UserApplications"));
                entity.HasMany(a => a.Roles)
                      .WithMany(r => r.Apps)
                      .UsingEntity(j => j.ToTable("AppRoles"));
            });
        }
    }
}