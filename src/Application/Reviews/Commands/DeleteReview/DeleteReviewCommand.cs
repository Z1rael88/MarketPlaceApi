using MarketPlaceApi.Application.Common.Interfaces;

namespace MarketPlaceApi.Application.Reviews.Commands.DeleteReview;

public record DeleteReviewCommand(int Id) :IRequest;

public class DeleteReviewCommandHandler(IApplicationDbContext dbContext, IUser user) : IRequestHandler<DeleteReviewCommand>
{
    public async Task Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(user.Id);
        var review = await dbContext.Reviews.Where(r => r.Id == command.Id)
            .FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound(command.Id, review);
        dbContext.Reviews.Remove(review);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
