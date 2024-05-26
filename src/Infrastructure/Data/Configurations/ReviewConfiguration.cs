using MarketPlaceApi.Application.Reviews.Queries;
using MarketPlaceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlaceApi.Infrastructure.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(r => r.ReviewText)
            .HasMaxLength(200);
        builder.Property(r => r.Rating)
            .IsRequired();
        builder
            .HasOne(r => r.Product)
            .WithMany(r => r.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade); 

    }
}
