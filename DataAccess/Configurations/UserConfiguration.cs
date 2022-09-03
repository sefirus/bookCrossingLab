using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);
        
        builder
            .Property(u => u.Email)
            .HasMaxLength(150);

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(150);

        builder
            .Property(u => u.LastName)
            .HasMaxLength(150);

        builder
            .HasOne<Picture>(u => u.ProfilePicture)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.ProfilePictureId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        
        builder
            .HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        builder
            .ToTable("Users");
    }
}