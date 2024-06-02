namespace RateThisDog.Abstractions;

public interface IDogRatingRepository
{
    Task<IDogRatingDto> GetRandom();
    Task AddRating(int dogId, decimal rating);
}