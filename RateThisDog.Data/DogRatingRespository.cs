using RateThisDog.Abstractions;

namespace RateThisDog.Data
{
    public class DogRatingRepository : IDogRatingRepository
    {
        public DogRatingRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

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

        private AppDbContext _context;
    }
}