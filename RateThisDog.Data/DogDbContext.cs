using System.Diagnostics;
using Microsoft.Extensions.Logging;
using RateThisDog.Data.Dto;

namespace RateThisDog.Data;

public class DogDbContext() : DbContext()
{
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<UserRating> UserRatings { get; set; }

    //TODO: remove and configure from outside
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("DataSource=/home/nistrum/dev/rate-this-dog/RateThisDog.Data/Sqlite/RateThisDog.db")
            .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Information)
            .EnableDetailedErrors(true)
            .EnableSensitiveDataLogging(true);

        base.OnConfiguring(optionsBuilder);
    }
}
