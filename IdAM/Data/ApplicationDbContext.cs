using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.Options;

namespace IdAM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<App> Apps { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppRoleClaim> AppRoleClaims { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var fakeApps = new List<App>();
            for (int i = 1; i <= 20; i++)
            {
                fakeApps.Add(new App { Id = i, Name = $"App {i}" });
            }

            builder.Entity<App>().HasData(fakeApps);
            builder.Entity<UserApplication>().HasKey(ua => new { ua.UserId, ua.AppId });
            builder.Entity<UserApplication>().HasOne(ua => ua.User).WithMany(u => u.UserApplications).HasForeignKey(ua => ua.UserId);
            builder.Entity<UserApplication>().HasOne(ua => ua.App).WithMany(a => a.UserApplications).HasForeignKey(ua => ua.AppId);

            builder.Entity<AppRole>().HasKey(ar => new { ar.RoleId, ar.AppId });
            builder.Entity<AppRole>().HasOne(ar => ar.Role).WithMany(r => r.AppRoles).HasForeignKey(ar => ar.RoleId);
            builder.Entity<AppRole>().HasOne(ar => ar.App).WithMany(a => a.AppRoles).HasForeignKey(ar => ar.AppId);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.Id).HasColumnType("nvarchar(450)");
                entity.HasMany(p => p.Roles).WithOne().HasForeignKey(p => p.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Claims).WithOne().HasForeignKey(e => e.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(r => r.Id).HasColumnType("nvarchar(450)");
                //entity.HasMany(r => r.Claims).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<AppRoleClaim>().HasOne(arc => arc.AppRole).WithMany(ar => ar.RoleClaims).HasForeignKey(arc => new { arc.RoleId, arc.AppId });
        }
    }
}