using RateThisDog.Abstractions;

namespace RateThisDog.Data.Dto;

public class DogRating : IDogRatingDto
{
    public int? DogID { get; set; }
    public required string ImageUrl { get; set; }
    public required decimal AverageRating { get; set; }
}