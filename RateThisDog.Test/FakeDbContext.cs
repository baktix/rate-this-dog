using Microsoft.EntityFrameworkCore;
using RateThisDog.Data;
using RateThisDog.Data.Dto;

namespace RateThisDog.Test;

public static class FakeDbContext
{
    public static AppDbContext Create()
    {
        return new AppDbContext(
            new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase($"TestDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options
                );
    }

    public static async Task Seed(AppDbContext context)
    {
        AddDog(context, 1, "woof.jpg", [3, 5, 4.5, 1]);
        AddDog(context, 2, "bark.jpg", [2.4, 3, 4.1, 5, 5]);
        AddDog(context, 3, "roll.jpg", [0.4, 0, 1, 1.1, 0.9]);
        AddDog(context, 4, "fetch.jpg", [0.3, 4, 3.5, 2, 5]);
        AddDog(context, 5, "sniff.jpg", [3, 3, 4.7, 4.8]);
        AddDog(context, 6, "lick.jpg", [2]);
        await context.SaveChangesAsync();
    }

    private static void AddDog(AppDbContext context, int dogId, string filename, double[] ratings)
    {
        context.Dogs.Add(new Dog()
        {
            ID = dogId,
            FileName = filename,
            UserRatings = ratings.Select(
                r => new UserRating() { DogID = dogId, Rating = r }
                ).ToList()
        });
    }
}