namespace RateThisDog.Abstractions;

public interface IDogDto
{
    int? ID { get; }
    string FileName { get; }
    ICollection<IUserRatingDto>? UserRatings { get; }
}