using RateThisDog.Data.Dto;

namespace RateThisDog.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Dog> Dogs { get; set; }
    public DbSet<UserRating> UserRatings { get; set; }
}
