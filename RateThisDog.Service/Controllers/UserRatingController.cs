using System.Collections;
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
    public IEnumerable Get()
    {
        throw new NotImplementedException();
    }
}
