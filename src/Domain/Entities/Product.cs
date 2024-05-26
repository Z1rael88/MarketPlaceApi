using System.ComponentModel.DataAnnotations;

namespace MarketPlaceApi.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string? Name { get; set; }
    [Range(0,5,ErrorMessage = "Rating must be between 0 and 5")]
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public string? PhotoUrl { get; set; }
    public ICollection<Review> Reviews { get; set; } = null!;
}
