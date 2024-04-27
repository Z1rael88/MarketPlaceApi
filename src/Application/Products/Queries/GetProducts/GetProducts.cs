using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Application.Products.Mappers;
using Microsoft.Extensions.DependencyInjection.Products.Queries.GetProducts;

namespace MarketPlaceApi.Application.Products.Queries.GetProducts;

public record GetProductsQuery : IRequest<ICollection<ProductDto>>;
public class GetAllProductsQueryHandler(IApplicationDbContext dbContext): IRequestHandler<GetProductsQuery,ICollection<ProductDto>>
{
    public async Task<ICollection<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<ProductDto> productResponses = await dbContext.Products
            .Select(product => product.ToProductDto())
            .ToListAsync(cancellationToken);
        return productResponses;
    }
}
