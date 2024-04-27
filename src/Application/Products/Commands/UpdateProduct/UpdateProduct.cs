using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Application.Products.Commands.CreateProduct;

namespace MarketPlaceApi.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest
{
    public int Id { get; set; } 
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public string? PhotoUrl { get; set; }
}

public class UpdateProductCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, product);

        product.Name = request.Name;
        product.Price = request.Price;
        product.PhotoUrl = request.PhotoUrl;
        product.Rating = request.Rating;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
