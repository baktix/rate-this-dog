using RateThisDog.Abstractions;
using RateThisDog.Data.Dto;

namespace RateThisDog.Data
{
    public class DogRatingRepository : IDogRatingRepository
    {
        public DogRatingRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddRating(IUserRatingDto userRating)
        {
            if (userRating.ID is not null)
                throw new ArgumentException(
                    $"{nameof(userRating)} with an existing {nameof(userRating.ID)} cannot be added"
                    );

            UserRating u = new UserRating
            {
                DogID = userRating.DogID,
                Rating = userRating.Rating,
            };

            await _context.UserRatings.AddAsync(u);
            await _context.SaveChangesAsync();
        }

        // challenges: To get at a random row we'll ideally skip(r).take(1)
        // which will need us to know the table size. the table size might
        // change in the moment betwen counting and randomising.  
        // if we start a transaction on our private context field, we run
        // the risk of another method using the context and our transaction.
        // we'd probably need to synclock the context everywhere or fail to
        // be thread-safe.
        // an alternative is to just try the operation and do it again 
        // if it didn't work. this shifts any performance impact away from 
        // the happy path.
        // TODO: can we fathom a unit test for the retry mechanism? zero rows
        // would simulate reading beyond the end of the rows.
        public async Task<IDogRatingDto> GetRandom()
        {
            const int retries = 5;
            for (int i = 0; i < retries; i++)
            {
                IQueryable<DogRating> query = GetAllDogRatingsQuery();

                int recordCount = await GetDogCount();
                Random random = new Random(Environment.TickCount);
                int randomRecord = random.Next(0, recordCount - 1);

                IDogRatingDto? ret = await query.Skip(randomRecord).FirstOrDefaultAsync();

                if (ret is not null)
                    return ret;

                await Task.Delay(TimeSpan.FromMilliseconds(200));
            }

            throw new InvalidOperationException($"Unable to fetch a random dog");
        }

        private IQueryable<DogRating> GetAllDogRatingsQuery() =>
            from dog in _context.Dogs
            join userRating in _context.UserRatings on dog.ID equals userRating.DogID
            into r
            from rating in r.DefaultIfEmpty()
            group rating by dog into g
            //TODO: do we want to inject a DogRating factory to do creation here?
            select new Dto.DogRating
            {
                DogID = g.Key.ID,
                ImageUrl = g.Key.FileName,
                AverageRating = (decimal)g.Average(u => u.Rating)
            };

        private async Task<int> GetDogCount() => await _context.Dogs.CountAsync();

        private AppDbContext _context;
    }
}