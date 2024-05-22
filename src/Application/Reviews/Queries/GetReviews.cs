using MarketPlaceApi.Application.Common.Interfaces;
using MarketPlaceApi.Application.Reviews.Mappers;
using MarketPlaceApi.Domain.Entities;

namespace MarketPlaceApi.Application.Reviews.Queries;

public record GetReviews() : IRequest<ICollection<ReviewDto>>;

public class GetReviewsQueryHandler(IApplicationDbContext dbContext,IUser user) : IRequestHandler<GetReviews, ICollection<ReviewDto>>
{
    public async  Task<ICollection<ReviewDto>> Handle(GetReviews request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(user.Id);
        
        List<ReviewDto> reviews = await dbContext.Reviews
            .Select(review => review.ToReviewDto())
            .ToListAsync(cancellationToken);
        return reviews;
    }
}
