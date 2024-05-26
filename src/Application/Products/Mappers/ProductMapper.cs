using MarketPlaceApi.Application.Products.Commands.CreateProduct;
using MarketPlaceApi.Application.Products.Queries.GetProducts;
using MarketPlaceApi.Application.Reviews.Mappers;
using MarketPlaceApi.Domain.Entities;

namespace MarketPlaceApi.Application.Products.Mappers;

public static class ProductMapper
{

    public static ProductDto ToProductDto(this Product product)
    {
        ProductDto productDto = new()
        {
           Id = product.Id,Reviews = product.Reviews.Select(reviews=>reviews.ToReviewDto()).ToArray() , Name = product.Name, PhotoUrl = product.PhotoUrl, Price = product.Price, Rating = product.Rating
        };
        return productDto;
    }
}
