using Microsoft.AspNetCore.Mvc;
using Moq;
using RateThisDog.Abstractions;
using RateThisDog.Data.Dto;
using RateThisDog.Service.Controllers.UserRating;

namespace RateThisDog.Test;

[TestClass]
public class UserRatingControllerTest
{
    [TestMethod]
    public async Task GetRandom_ReturnsData()
    {
        var logger = FakeLogger.Create<UserRatingController>();
        var repo = new Mock<IDogRatingRepository>();
        IDogRatingDto testDogRating = new DogRating()
        {
            DogID = 1,
            AverageRating = 3.5m,
            ImageUrl = "dog.jpg"
        };
        repo.Setup(r => r.GetRandom())
            .ReturnsAsync(testDogRating)
            .Verifiable();

        var exceptionUtility = new Mock<IExceptionUtility>();

        UserRatingController controller = new(logger, exceptionUtility.Object, repo.Object);

        IDogRatingResponse res = await controller.GetRandom();

        repo.Verify(r => r.GetRandom(), Times.Once);
        Assert.IsNotNull(res);
        Assert.AreEqual(testDogRating.DogID, res.DogID);
        Assert.AreEqual(testDogRating.AverageRating, res.AverageRating);
        Assert.AreEqual(testDogRating.ImageUrl, res.ImageUrl);
    }

    [TestMethod]
    public async Task AddRating_AddsData()
    {
        const int testId = 1;
        const decimal testRating = 2.7m;

        var logger = FakeLogger.Create<UserRatingController>();
        var repo = new Mock<IDogRatingRepository>();
        repo.Setup(r => r.AddRating(It.IsAny<IUserRatingDto>()))
            .Verifiable();
        var exceptionUtility = new Mock<IExceptionUtility>();
        UserRatingController controller = new(logger, exceptionUtility.Object, repo.Object);

        IActionResult res = await controller.AddRating(new DogRatingRequest
        {
            DogID = testId,
            UserRating = testRating
        });

        Assert.IsInstanceOfType<CreatedResult>(res);
        repo.Verify(r => r.AddRating(
            It.Is<IUserRatingDto>(u =>
                u.DogID == testId
                && u.Rating == (double)testRating)
            ), Times.Once);
    }
}