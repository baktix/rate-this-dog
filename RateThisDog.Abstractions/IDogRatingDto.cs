namespace RateThisDog.Abstractions;

public interface IDogRatingDto
{
    int? DogID { get; set; }
    string ImageUrl { get; set; }
    decimal AverageRating { get; set; }
}
