using RateThisDog.Abstractions;

namespace RateThisDog.Service.Controllers.UserRating;

public class DogRatingRequest : IDogRatingRequest
{
    public int DogID { get; set; }
    public decimal UserRating { get; set; }
}