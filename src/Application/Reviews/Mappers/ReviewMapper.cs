using MarketPlaceApi.Application.Reviews.Commands.BaseCommandReview;
using MarketPlaceApi.Application.Reviews.Queries;
using MarketPlaceApi.Domain.Entities;

namespace MarketPlaceApi.Application.Reviews.Mappers;

public static class ReviewMapper
{
    public static ReviewDto ToReviewDto(this Review review)
    {
        ReviewDto reviewDto = new() {Id = review.Id, Rating = review.Rating, ReviewText = review.ReviewText };
        return reviewDto;
    }
    
}
