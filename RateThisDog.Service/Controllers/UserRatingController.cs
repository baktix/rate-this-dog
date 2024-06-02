using Microsoft.AspNetCore.Mvc;

namespace RateThisDog.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRatingController : ControllerBase
{
    private readonly ILogger<UserRatingController> _logger;

    public UserRatingController(ILogger<UserRatingController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
