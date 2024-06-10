namespace RateThisDog.Data.Dto;

using RateThisDog.Abstractions;

public class Dog : IDogDto
{
    public int? ID { get; set; }
    public required string FileName { get; set; }

    public ICollection<UserRating>? UserRatings { get; set; }

    //TODO: ICollection<T> isn't covariant, this code doesn't thrill me, our list could be big, refactor/delete?
    ICollection<IUserRatingDto>? IDogDto.UserRatings => UserRatings?.Cast<IUserRatingDto>().ToList();
}