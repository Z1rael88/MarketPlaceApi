using MarketPlaceApi.Application.Products.Commands.CreateProduct;
using MarketPlaceApi.Application.Products.Queries.GetProducts;
using MarketPlaceApi.Domain.Entities;

namespace MarketPlaceApi.Application.Products.Mappers;

public static class ProductMapper
{

    public static ProductDto ToProductDto(this Product product)
    {
        ProductDto productDto = new()
        {
            Name = product.Name, PhotoUrl = product.PhotoUrl, Price = product.Price, Rating = product.Rating
        };
        return productDto;
    }
}
