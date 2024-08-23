using AuthApp.Configurations;
using AuthApp.Constants;
using AuthApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Data {
    public class AppDbContext : IdentityDbContext<AppUser> {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        public DbSet<Events> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            modelBuilder.Entity<UserService>()
               .HasKey(us => new { us.UserId, us.ServiceId });

            modelBuilder.Entity<UserService>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserServices)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserService>()
                .HasOne(us => us.Service)
                .WithMany(s => s.UserServices)
                .HasForeignKey(us => us.ServiceId);

            modelBuilder.Entity<Events>()
            .HasOne(e => e.Client)
            .WithMany(u => u.CreatedRequests)
            .HasForeignKey(e => e.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Events>()
                .HasOne(e => e.Prestataire)
                .WithMany(u => u.AssignedRequests)
                .HasForeignKey(e => e.PrestataireId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppUser>()
        .Property(u => u.RoleUser)
        .HasConversion(
            v => v.ToString(),
            v => (UserRoles)Enum.Parse(typeof(UserRoles), v))
        .HasColumnType("text");

            base.OnModelCreating(modelBuilder);
        }
    }
}
