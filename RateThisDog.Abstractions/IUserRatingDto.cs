namespace RateThisDog.Abstractions;

public interface IUserRatingDto
{
    int? ID { get; }
    int? DogID { get; }
    double? Rating { get; }
}