using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Application.Products.Mappers;

namespace MarketPlaceApi.Application.Products.Queries.GetProducts;

public record GetProductById(int Id) : IRequest<ProductDto>;
public class GetProductByIdQueryHandler(IApplicationDbContext dbContext) : IRequestHandler<GetProductById,ProductDto>
{
    public async Task<ProductDto> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        var productResponse = await dbContext.Products
            .Where(p => p.Id == request.Id)
            .Include(r => r.Reviews)
            .Select(product => product.ToProductDto())
            .FirstOrDefaultAsync(cancellationToken);
        Guard.Against.Null(productResponse);
        return productResponse;
    }
}
