using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Application.Products.Mappers;

namespace MarketPlaceApi.Application.Products.Queries.GetProducts;

public record GetProductsQuery : IRequest<ICollection<ProductDto>>;
public class GetAllProductsQueryHandler(IApplicationDbContext dbContext): IRequestHandler<GetProductsQuery,ICollection<ProductDto>>
{
    public async Task<ICollection<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<ProductDto> productResponses = await dbContext.Products
            .Include(r=>r.Reviews)
            .Select(product => product.ToProductDto())
            .ToListAsync(cancellationToken);
        return productResponses;
    }
}
