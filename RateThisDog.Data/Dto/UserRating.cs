namespace RateThisDog.Data.Dto;

using RateThisDog.Abstractions;

public class UserRating : IUserRatingDto
{
    public int? ID { get; set; }
    public int? DogID { get; set; }
    public required double? Rating
    {
        get => _rating;
        set
        {
            if (value != null && (value < 0 || value > 5))
                throw new ArgumentOutOfRangeException(nameof(value));

            _rating = value;
        }
    }

    private double? _rating;
}