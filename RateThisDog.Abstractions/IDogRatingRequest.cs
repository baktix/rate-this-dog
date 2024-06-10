namespace RateThisDog.Abstractions;

public interface IDogRatingRequest
{
    int DogID { get; set; }
    decimal UserRating { get; set; }
}