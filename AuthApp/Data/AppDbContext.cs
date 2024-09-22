using AuthApp.Configurations;
using AuthApp.Constants;
using AuthApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<POS> POSs { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        public DbSet<POSClient> POSClients { get; set; }
        public DbSet<POSPrestataire> POSPrestataires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply custom configurations if any
            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            // Configure AppUser
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.UserServices)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure UserService
            modelBuilder.Entity<UserService>()
                .HasKey(us => new { us.UserId, us.ServiceId });

            modelBuilder.Entity<UserService>()
                .HasOne(us => us.Service)
                .WithMany(s => s.UserServices)
                .HasForeignKey(us => us.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Service
            modelBuilder.Entity<Service>()
                .HasOne(s => s.POS)
                .WithMany(p => p.Services)
                .HasForeignKey(s => s.POSId);

            // Configure POS
            modelBuilder.Entity<POS>()
                .HasOne(p => p.Admin)
                .WithMany(u => u.AdminPOSs)
                .HasForeignKey(p => p.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<POS>()
                .HasMany(p => p.Clients)
                .WithMany(u => u.ClientPOSs)
                .UsingEntity<POSClient>(
                    j => j.HasOne<AppUser>().WithMany().HasForeignKey("ClientId"),
                    j => j.HasOne<POS>().WithMany().HasForeignKey("POSId")
                );

            modelBuilder.Entity<POS>()
                .HasMany(p => p.Prestataires)
                .WithMany(u => u.PrestatairePOSs)
                .UsingEntity<POSPrestataire>(
                    j => j.HasOne<AppUser>().WithMany().HasForeignKey("PrestataireId"),
                    j => j.HasOne<POS>().WithMany().HasForeignKey("POSId")
                );

            // Configure Events
            modelBuilder.Entity<Events>()
                .HasOne(e => e.Client)
                .WithMany(c => c.CreatedRequests)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Events>()
                .HasOne(e => e.Prestataire)
                .WithMany(p => p.AssignedRequests)
                .HasForeignKey(e => e.PrestataireId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure PasswordResetToken
            modelBuilder.Entity<PasswordResetToken>()
                .HasKey(e => e.Id);

            // Configure RoleUser Enum
            modelBuilder.Entity<AppUser>()
                .Property(u => u.RoleUser)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRoles)Enum.Parse(typeof(UserRoles), v))
                .HasColumnType("text");

            modelBuilder.Entity<POSClient>()
       .HasKey(pc => new { pc.POSId, pc.ClientId });

            modelBuilder.Entity<POSClient>()
                .HasOne(pc => pc.POS)
                .WithMany(p => p.POSClients)
                .HasForeignKey(pc => pc.POSId);

            modelBuilder.Entity<POSClient>()
                .HasOne(pc => pc.Client)
                .WithMany(u => u.POSClients)
                .HasForeignKey(pc => pc.ClientId);

            modelBuilder.Entity<POSPrestataire>()
                .HasKey(pp => new { pp.POSId, pp.PrestataireId });

            modelBuilder.Entity<POSPrestataire>()
                .HasOne(pp => pp.POS)
                .WithMany(p => p.POSPrestataires)
                .HasForeignKey(pp => pp.POSId);

            modelBuilder.Entity<POSPrestataire>()
                .HasOne(pp => pp.Prestataire)
                .WithMany(u => u.POSPrestataires)
                .HasForeignKey(pp => pp.PrestataireId);
        }
    }

}