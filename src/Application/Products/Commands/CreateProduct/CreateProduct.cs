using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Domain.Entities;

namespace MarketPlaceApi.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public string? PhotoUrl { get; set; }
}
public class CreateProductCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateProductCommand,int>
{
    public async  Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Guard.Against.Null(user.Id);
        var product = new Product
        {
            Name = command.Name, Price = command.Price, PhotoUrl = command.PhotoUrl, Rating = command.Rating
        };
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}
