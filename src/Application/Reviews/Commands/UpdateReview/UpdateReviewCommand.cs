using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Application.Reviews.Mappers;
using MarketPlaceApi.Application.Reviews.Queries;

namespace MarketPlaceApi.Application.Reviews.Commands.UpdateReview;

public record UpdateReviewCommand : BaseCommandReview.BaseCommandReview, IRequest<ReviewDto>
{
    public int Id { get; set; }
} 

public class UpdateReviewCommandHandler(IApplicationDbContext dbContext,IUser user) : IRequestHandler<UpdateReviewCommand,ReviewDto>
{
    public async Task<ReviewDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(user.Id);
        
        var review = await dbContext.Reviews.Where(r => r.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        Guard.Against.NotFound(request.Id, review);

        review.ReviewText = request.ReviewText;
        review.Rating = request.Rating;

        await dbContext.SaveChangesAsync(cancellationToken);
        return review.ToReviewDto();
    }
}
