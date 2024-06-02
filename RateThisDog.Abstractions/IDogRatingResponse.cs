namespace RateThisDog.Abstractions;

public interface IDogRatingResponse
{
    int DogID { get; set; }
    string ImageUrl { get; set; }
    decimal AverageRating { get; set; }
}
