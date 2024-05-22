namespace MarketPlaceApi.Application.Reviews.Queries;

public record ReviewDto
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; } = String.Empty;
}
