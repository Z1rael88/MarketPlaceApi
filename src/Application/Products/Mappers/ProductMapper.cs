using MarketPlaceApi.Application.Products.Commands.CreateProduct;
using MarketPlaceApi.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Products.Queries.GetProducts;

namespace MarketPlaceApi.Application.Products.Mappers;

public static class ProductMapper
{
    public static Product ToProduct(this CreateProductCommand command)
    {
        Product product = new()
        {
            Name = command.Name, Price = command.Price, PhotoUrl = command.PhotoUrl, Rating = command.Rating
        };
        return product;
    }

    public static ProductDto ToProductDto(this Product product)
    {
        ProductDto productDto = new()
        {
            Name = product.Name, PhotoUrl = product.PhotoUrl, Price = product.Price, Rating = product.Rating
        };
        return productDto;
    }
}
