using RateThisDog.Abstractions;

public class FakeDogRatingRepository : IDogRatingRepository
{
    public async Task<IDogRatingDto> GetRandom()
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }

    public async Task AddRating(int dogId, decimal rating)
    {
        await Task.Delay(1);
        throw new NotImplementedException();
    }
}