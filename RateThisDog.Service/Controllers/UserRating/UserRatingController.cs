using Microsoft.AspNetCore.Mvc;
using RateThisDog.Abstractions;

namespace RateThisDog.Service.Controllers.UserRating;

[ApiController]
[Route("[controller]")]
public class UserRatingController : ControllerBase
{
    private readonly ILogger<UserRatingController> _logger;
    private readonly IDogRatingRepository _repository;

    public UserRatingController(ILogger<UserRatingController> logger, IDogRatingRepository repository)
    {
        _logger = logger;
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    public async Task<IDogRatingResponse> GetRandom()
    {
        //TODO: catch a DB issue and say something apologetic
        //TODO: use the logger
        IDogRatingDto dto = await _repository.GetRandom();
        //TODO: factory-ise
        return new DogRatingResponse
        {
            DogID = dto.DogID ?? throw new NullReferenceException("DogID cannot be null"),
            AverageRating = dto.AverageRating,
            ImageUrl = dto.ImageUrl
        };
    }

    [HttpPost]
    public async Task<IActionResult> AddRating(int dogId, decimal rating)
    {
        if (rating < 0 || rating > 5)
            throw new ArgumentOutOfRangeException(nameof(rating));

        //TODO: factory
        IUserRatingDto dto = new RateThisDog.Data.Dto.UserRating
        {
            DogID = dogId,
            Rating = (double)rating,
        };
        await _repository.AddRating(dto);

        return Ok();
    }
}
