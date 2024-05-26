using MarketPlaceApi.Application.Reviews.Queries;

namespace MarketPlaceApi.Application.Products.Queries.GetProducts;

public record ProductDto
{
    public required int Id { get; set; }
    public required string? Name { get; set; }
    public required decimal Price { get; set; }
    public required int Rating { get; set; }
    public required string? PhotoUrl { get; set; }
    public  required ReviewDto[] Reviews { get; set; }
}
