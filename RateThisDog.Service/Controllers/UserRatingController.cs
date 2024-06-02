using Microsoft.AspNetCore.Mvc;
using RateThisDog.Abstractions;

namespace RateThisDog.Service.Controllers;

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
        //TODO: unit testing, implementation, exception handling, logging
        await Task.Delay(1);
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> AddRating(int dogId, decimal rating)
    {
        //TODO: unit testing, implementation, exception handling, logging
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}
