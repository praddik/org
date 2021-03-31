using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityAlwaysColumn();

            builder.HasIndex(u => u.Id)
                .IsUnique();

            builder.Property(u => u.Access)
                .HasDefaultValue(AccessLevel.User)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(320)
                .IsRequired();

            builder.Property(u => u.Phone)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasOne(u => u.Company)
                .WithOne()
                .HasForeignKey<User>(u => u.CompanyId);

            builder.HasIndex(u => u.CompanyId);

            builder.Property(u => u.PasswordHash)
                .IsRequired();
        }
    }
}
