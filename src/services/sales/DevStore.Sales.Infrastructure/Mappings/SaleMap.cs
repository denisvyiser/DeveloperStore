using DevStore.Sales.Domain.Moldes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Infrastructure.Mappings
{
    internal class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Branch).HasMaxLength(100).IsRequired();
            builder.Property(c => c.TotalAmount).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Status).IsRequired();
            builder.OwnsOne(c => c.Customer)
                .Property(c => c.CustomerId);
            builder.OwnsOne(c => c.Customer)
                .Property(c => c.CustomerName);
            builder.Property(c => c.Version).IsConcurrencyToken();
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.UpdatedAt);
        }
    }
}
