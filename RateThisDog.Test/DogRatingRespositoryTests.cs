using Microsoft.EntityFrameworkCore;
using RateThisDog.Abstractions;
using RateThisDog.Data;
using RateThisDog.Data.Dto;

namespace RateThisDog.Test;

[TestClass]
public class DogRatingRespositoryTest
{
    [TestMethod]
    public async Task GetRandom_ReturnsValidResult()
    {
        using var context = FakeDbContext.Create();
        await FakeDbContext.Seed(context);
        IDogRatingRepository repo = new DogRatingRepository(context);

        IDogRatingDto result = await repo.GetRandom();

        Assert.IsNotNull(result);
        Assert.IsTrue(result.DogID >= 1 && result.DogID <= 6);
        Assert.IsNotNull(result.ImageUrl);
        Assert.IsTrue(result.AverageRating >= 1 && result.AverageRating <= 5);
    }

    [TestMethod]
    public async Task AddRating_UpdatesDbContext()
    {
        const int testId = 1;
        const decimal testRating = 2.5m;

        using var context = FakeDbContext.Create();
        await FakeDbContext.Seed(context);

        IDogRatingRepository repo = new DogRatingRepository(context);
        int userRatingsCount = context.UserRatings.Count(d => d.DogID == testId);

        await repo.AddRating(new UserRating { DogID = 1, Rating = (double)testRating });

        IDogDto testDog = context.Dogs.Include(d => d.UserRatings).Single(d => d.ID == 1);

        Assert.IsNotNull(testDog.UserRatings);
        Assert.AreEqual(userRatingsCount + 1, testDog.UserRatings.Count);
        Assert.AreEqual(testRating, (decimal)testDog.UserRatings.Last().Rating);
    }
}