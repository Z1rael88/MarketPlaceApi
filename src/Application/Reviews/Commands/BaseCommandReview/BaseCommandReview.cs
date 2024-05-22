namespace MarketPlaceApi.Application.Reviews.Commands.BaseCommandReview;

public record BaseCommandReview 
{
    public int Rating { get; set; }
    public string ReviewText { get; set; } = String.Empty;
}
