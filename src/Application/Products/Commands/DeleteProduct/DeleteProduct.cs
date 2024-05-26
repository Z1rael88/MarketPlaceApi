using MarketPlaceApi.Application.Common.Interfaces;

namespace MarketPlaceApi.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;

public class DeleteProductCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
            .Include(r => r.Reviews)
            .FirstOrDefaultAsync(p => p.Id == request.Id,cancellationToken);

        Guard.Against.NotFound(request.Id, product);

        dbContext.Reviews.RemoveRange(product.Reviews);
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
