using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateThisDog.Abstractions;

namespace RateThisDog.Service.Controllers.UserRating;

[ApiController]
[Route("[controller]")]
public class UserRatingController : ControllerBase
{
    private readonly ILogger<UserRatingController> _logger;
    private readonly IExceptionUtility _exceptionUtility;
    private readonly IDogRatingRepository _repository;

    public UserRatingController(
        ILogger<UserRatingController> logger,
        IExceptionUtility exceptionUtility,
        IDogRatingRepository repository)
    {
        _logger = logger;
        _exceptionUtility = exceptionUtility ?? throw new ArgumentNullException(nameof(exceptionUtility));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    }

    [HttpGet]
    [Route("random")]
    public async Task<IDogRatingResponse> GetRandom()
    {
        //TODO: catch a DB issue and say something apologetic
        //TODO: use the logger

        IDogRatingDto dto = await _repository.GetRandom();

        return new DogRatingResponse
        {
            DogID = dto.DogID ?? throw new NullReferenceException("DogID cannot be null"),
            AverageRating = dto.AverageRating,
            ImageUrl = dto.ImageUrl
        };
    }

    [HttpPost]
    public async Task<IActionResult> AddRating(DogRatingRequest request)
    {
        if (request.UserRating < 0 || request.UserRating > 5)
            return Problem("Rating must be between 1 and 5",
                statusCode: (int)HttpStatusCode.BadRequest);

        IUserRatingDto dto = new RateThisDog.Data.Dto.UserRating
        {
            DogID = request.DogID,
            Rating = (double)request.UserRating,
        };

        try
        {
            await _repository.AddRating(dto);
        }
        catch (DbUpdateException dbUpdateException)
        {
            return _exceptionUtility.ProcessException(
                dbUpdateException, "Unable to add rating. Data error."
                );
        }
        catch (Exception ex)
        {
            return _exceptionUtility.ProcessException(
                ex, "Unable to add rating. Internal server error."
                );
        }

        return Created();
    }
}
