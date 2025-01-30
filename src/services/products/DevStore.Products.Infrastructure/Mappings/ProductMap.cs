using DevStore.Products.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Infrastructure.Mappings
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Price).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Category).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Image).IsRequired();
            builder.OwnsOne(c => c.Rating)
                .Property(c => c.Rate);
            builder.OwnsOne(c => c.Rating)
                .Property(c => c.Count);
            //builder.Property(c => c.Version).IsConcurrencyToken();
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.UpdatedAt);

        }
    }
}
