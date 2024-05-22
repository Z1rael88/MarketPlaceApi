namespace MarketPlaceApi.Application.Products.Queries.GetProducts;

public record ProductDto
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public string? PhotoUrl { get; set; }
}
