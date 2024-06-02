namespace RateThisDog.Data.Dto;

public class UserRating
{
    public int? ID { get; set; }
    public int? DogID { get; set; }
    public required double Rating { get; set; }
}