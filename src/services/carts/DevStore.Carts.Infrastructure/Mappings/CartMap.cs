using DevStore.Carts.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Carts.Infrastructure.Mappings
{
    public class CartMap : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.UserId).HasMaxLength(50).IsRequired().IsUnicode(true);
            builder.Property(c => c.Status);
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.Version).IsConcurrencyToken();
            builder.Property(c => c.UpdatedAt);
            builder.HasMany(c => c.CartProduct)
                .WithOne(c => c.Cart).HasForeignKey(c => c.CartId);
        }
    }
}
