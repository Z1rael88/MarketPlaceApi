using System.Security.Claims;

using MarketPlaceApi.Application.Common.Interfaces;

namespace MarketPlaceApi.Web.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
}
