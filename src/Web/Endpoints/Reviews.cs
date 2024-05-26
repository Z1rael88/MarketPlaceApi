using System.Collections;
using MarketPlaceApi.Application.Reviews.Commands.CreateReview;
using MarketPlaceApi.Application.Reviews.Commands.DeleteReview;
using MarketPlaceApi.Application.Reviews.Commands.UpdateReview;
using MarketPlaceApi.Application.Reviews.Queries;
using MarketPlaceApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlaceApi.Web.Endpoints;

public class Reviews : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateReviewEndpoint)
            .MapDelete(DeleteReviewEndpoint, "{id}")
            .MapPut(UpdateReviewEndpoint, "{id}")
            .MapGet(GetReviewsEndpoint);
    }

    public Task<int> CreateReviewEndpoint(CreateReviewCommand command, ISender sender)
    {
        return sender.Send(command);
    }

    public async Task DeleteReviewEndpoint(int id, ISender sender)
    {
        await sender.Send(new DeleteReviewCommand(id));
    }

    public async Task<ReviewDto> UpdateReviewEndpoint(ISender sender,int id,UpdateReviewCommand command)
    {
        command.Id = id;
            return await sender.Send(command);
    }

    public async Task<ICollection<ReviewDto>> GetReviewsEndpoint( [AsParameters] GetReviews query, ISender sender)
    {
        return await sender.Send(query);
    }
}
