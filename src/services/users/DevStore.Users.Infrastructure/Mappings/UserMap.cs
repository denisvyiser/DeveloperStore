using DevStore.Users.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.UserName).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(20).IsRequired();

            builder.OwnsOne(u => u.Name,
            n =>
            {
                n.Property(nn => nn.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();

                n.Property(nn => nn.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
            });

            builder.OwnsOne(u => u.Address,
            a =>
            {

                a.Property(aa => aa.City)
                    .HasColumnName("City")
                    .IsRequired();

                a.Property(aa => aa.Street)
                    .HasColumnName("Street")
                    .IsRequired();

                a.Property(aa => aa.Number)
                    .HasColumnName("Number")
                    .IsRequired();

                a.Property(aa => aa.ZipCode)
                    .HasColumnName("ZipCode")
                    .IsRequired();

                a.OwnsOne(aa => aa.Geolocation,
                    g =>
                    {
                        g.Property(gp => gp.Latitude)
                            .HasColumnName("Latitude")
                            .IsRequired();

                        g.Property(gp => gp.Longitude)
                            .HasColumnName("Longitude")
                            .IsRequired();
                    });
            });


            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.Role).HasMaxLength(20).IsRequired();
            //builder.Property(c => c.Version).IsConcurrencyToken(); Concurrency disabled
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.UpdatedAt);
        }
    }
}
