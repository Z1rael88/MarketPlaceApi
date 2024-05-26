namespace MarketPlaceApi.Domain.Entities;

public record Review
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public int ProductId { get; set; }
    public string ReviewText { get; set; } = String.Empty;
    public Product? Product { get; set; }
}
