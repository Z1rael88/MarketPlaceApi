using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Application.Reviews.Mappers;
using MarketPlaceApi.Domain.Entities;

namespace MarketPlaceApi.Application.Reviews.Commands.CreateReview;

public record CreateReviewCommand : IRequest<int>
{
    public int  Id { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; } = String.Empty;
    public int ProductId { get; set; }
}

public class CreateReviewCommandHandler(IApplicationDbContext dbContext,IUser user) : IRequestHandler<CreateReviewCommand,int>
{
    public async Task<int> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(user.Id);
        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == command.ProductId,cancellationToken);

        Guard.Against.Null(product);

        Review review = command.ToReview(product);
        dbContext.Reviews.Add(review);
        await dbContext.SaveChangesAsync(cancellationToken);
        return review.Id;
    }
}
