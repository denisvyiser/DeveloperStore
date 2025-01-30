using DevStore.Sales.Domain.Moldes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Sales.Infrastructure.Mappings
{
    public class SaleProductMap : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {

            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId).IsRequired();
            builder.Property(c => c.ProductTitle).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ProductImage).IsRequired();
            builder.Property(c => c.Quantity).IsRequired();
            builder.Property(c => c.UnitPrice).IsRequired();
            builder.Property(c => c.Discount).IsRequired();
            builder.Property(c => c.SaleId).IsRequired();
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.Version).IsConcurrencyToken();
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.UpdatedAt);
        }
    }
}