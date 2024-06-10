using RateThisDog.Abstractions;

namespace RateThisDog.Service.Controllers.UserRating;

public class DogRatingResponse : IDogRatingResponse
{
    public required int DogID { get; set; }
    public required string ImageUrl { get; set; }
    public required decimal AverageRating { get; set; }
}