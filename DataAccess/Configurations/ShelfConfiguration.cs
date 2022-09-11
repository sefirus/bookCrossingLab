using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
{
    public void Configure(EntityTypeBuilder<Shelf> builder)
    {
        builder
            .HasKey(sh => sh.Id);

        builder
            .Property(sh => sh.FormattedAddress)
            .HasMaxLength(250);

        builder
            .Property(sh => sh.Title)
            .HasMaxLength(250);

        builder
            .ToTable("Shelves");
    }
}