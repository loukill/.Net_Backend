using AuthApp.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApp.Configurations {
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole> {
        public void Configure(EntityTypeBuilder<IdentityRole> modelBuilder) {
            List<IdentityRole> roles = new List<IdentityRole> {
                new IdentityRole {
                    Name = UserRoles.Admin.ToString(),
                    NormalizedName = UserRoles.Admin.ToString().ToUpper()
                },
                new IdentityRole
                {
                    Name = UserRoles.Prestataire.ToString(),
                    NormalizedName = UserRoles.Prestataire.ToString().ToUpper()
                },
                new IdentityRole {
                    Name = UserRoles.Client.ToString(),
                    NormalizedName = UserRoles.Client.ToString().ToUpper()
                }  
            };
            modelBuilder.HasData(roles);
        }
    }
}
