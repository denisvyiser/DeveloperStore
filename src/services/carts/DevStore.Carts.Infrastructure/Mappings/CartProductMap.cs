using DevStore.Carts.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Carts.Infrastructure.Mappings
{
    internal class CartProductMap : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.ProductTitle).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ProductImage);
            builder.Property(c => c.UnitPrice);
            builder.Property(c => c.Quantity);
            builder.Property(c => c.CartId);
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.Version).IsConcurrencyToken();
            builder.Property(c => c.UpdatedAt);
        }
    }
}