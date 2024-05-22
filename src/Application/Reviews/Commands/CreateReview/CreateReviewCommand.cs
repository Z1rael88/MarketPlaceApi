using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Domain.Entities;

namespace MarketPlaceApi.Application.Reviews.Commands.CreateReview;

public record CreateReviewCommand : IRequest<int>
{
    public int  Id { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; } = String.Empty;
}

public class CreateReviewCommandHandler(IApplicationDbContext dbContext,IUser user) : IRequestHandler<CreateReviewCommand,int>
{
    public async Task<int> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(user.Id);
        var review = new Review { Id = command.Id, Rating = command.Rating, ReviewText = command.ReviewText };
        dbContext.Reviews.Add(review);
        await dbContext.SaveChangesAsync(cancellationToken);
        return review.Id;
    }
}
