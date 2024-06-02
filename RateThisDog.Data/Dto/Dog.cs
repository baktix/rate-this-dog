namespace RateThisDog.Data.Dto;

public class Dog
{
    public int? ID { get; set; }
    public required string FileName { get; set; }
    public ICollection<UserRating>? UserRatings { get; set; }
}