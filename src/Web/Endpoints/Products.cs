using MarketPlaceApi.Application.Products.Commands.CreateProduct;
using MarketPlaceApi.Application.Products.Commands.DeleteProduct;
using MarketPlaceApi.Application.Products.Commands.UpdateProduct;
using MarketPlaceApi.Application.Products.Queries.GetProducts;

namespace MarketPlaceApi.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateProductEndpoint)
            .MapDelete(DeleteProductEndpoint, "{Id}")
            .MapGet(GetProductsEndpoint)
            .MapPut(UpdateProductEndpoint, "{id}")
            .MapGet(GetProductByIdEndpoint,"{id}");
    }

    public  Task<int> CreateProductEndpoint(CreateProductCommand command,ISender sender)
    {
        return sender.Send(command);
    } 
    public async Task<IResult> DeleteProductEndpoint(int Id,ISender sender)
    {
        await sender.Send(new DeleteProductCommand(Id));
        return Results.NoContent();
    }

    public async Task<ICollection<ProductDto>> GetProductsEndpoint(ISender sender,[AsParameters] GetProductsQuery query)
    {
       return await sender.Send(query);
    }

    public async Task<IResult> UpdateProductEndpoint(ISender sender, UpdateProductCommand command,int id)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<ProductDto> GetProductByIdEndpoint(ISender sender,int id)
    {
        var query = new GetProductById(id);
        return await sender.Send(query);
    }
}
