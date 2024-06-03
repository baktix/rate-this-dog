namespace RateThisDog.Abstractions;

public interface IDogRatingRepository
{
    //TODO: this probably belongs out in UserRatingRespository
    Task AddRating(IUserRatingDto userRating);
    Task<IDogRatingDto> GetRandom();
}