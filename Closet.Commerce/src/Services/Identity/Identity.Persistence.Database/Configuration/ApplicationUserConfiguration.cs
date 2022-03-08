using Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Database.Configuration
{
    public class ApplicationUserConfiguration
    {
        public ApplicationUserConfiguration(EntityTypeBuilder<ApplicationUser> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Id);
            entityTypeBuilder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(e => e.LastName).IsRequired().HasMaxLength(100);

            entityTypeBuilder.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();
        }
    }
}