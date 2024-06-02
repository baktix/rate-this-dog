namespace RateThisDog.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateThisDog.Data.Dto;

public class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.HasKey(e => e.ID);
        builder.Property(e => e.FileName).HasMaxLength(250);
        builder.HasMany(e => e.UserRatings)
            .WithOne()
            .HasForeignKey(u => u.DogID)
            .HasPrincipalKey(d => d.ID);
    }
}