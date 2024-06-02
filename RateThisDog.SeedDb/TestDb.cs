// temp, check the DB context is in shape and we can get optimal SQL for our use case
// starting with sqlite because my laptop is slow. will load it onto MSSQL when we're out of development.

// TODO: remove when DB is finalised

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RateThisDog.Data;
using RateThisDog.Data.Dto;

namespace RateThisDog.SeedDb;

public static class TestDb
{
    public static async Task Run()
    {
        using AppDbContext context = new(
            new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("DataSource=/home/nistrum/dev/rate-this-dog/sqlite/rate-this-dog/sqlite/RateThisDog.db")
            .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Information)
            .EnableDetailedErrors(true)
            .EnableSensitiveDataLogging(true)
            .Options
        );

        await context.UserRatings.ExecuteDeleteAsync();
        await context.Dogs.ExecuteDeleteAsync();

        Console.WriteLine($"Cleared DB, {context.Dogs.Count()} dogs in DB");

        Dog testDog1 = new()
        {
            FileName = "woof.jpg",
            UserRatings = [
                new() { Rating = 3.5d },
                new() { Rating = 4d },
                new() { Rating = 2.7d },
                new() { Rating = 4.1d },
                new() { Rating = 3d },
                new() { Rating = 1.2d },
                new() { Rating = 3.8d },
                new() { Rating = 1.1d },
                new() { Rating = 4.2d },
                new() { Rating = 2d },
                new() { Rating = 2.3d },
                new() { Rating = 2.7d }
            ]
        };

        context.Dogs.Add(testDog1);
        await context.SaveChangesAsync();

        Console.WriteLine($"Added test dog, {context.Dogs.Count()} dogs in DB");

        var ratings = from dog in context.Dogs //.Include(d => d.UserRatings)
                      join userRating in context.UserRatings on dog.ID equals userRating.DogID
                          into r
                      from rating in r.DefaultIfEmpty()
                          //where dog.ID == 1
                      group rating by dog into g
                      select new { DogID = g.Key.ID, g.Key.FileName, Rating = g.Average(u => u.Rating) };

        // Unhandled exception. System.NotSupportedException: SQLite cannot apply aggregate 
        // operator 'Average' on expressions of type 'decimal'. Convert the values to a supported
        // type, or use LINQ to Objects to aggregate the results on the client side.

        // https://stackoverflow.com/questions/77627624/sqlite-cannot-apply-aggregate-operator-sum-on-expressions-of-type-decimal-u
        // "Use double instead". we're going to have some mild inaccuracy in our averages which 
        // our test dog demonstrates.

        //TODO: It's not a critical issue but we should 'log a ticket' to switch to decimal 
        // when we use SQL Server later.

        foreach (var rating in ratings)
            Console.WriteLine($"Dog: {rating.DogID}, Filename: {rating.FileName}, Rating: {rating.Rating:0.00}");
    }
}