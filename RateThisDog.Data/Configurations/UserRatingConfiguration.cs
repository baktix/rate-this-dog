namespace RateThisDog.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateThisDog.Data.Dto;

public class UserRatingConfiguration : IEntityTypeConfiguration<UserRating>
{
    public void Configure(EntityTypeBuilder<UserRating> builder)
    {
        builder.HasKey(e => e.ID);
    }
}