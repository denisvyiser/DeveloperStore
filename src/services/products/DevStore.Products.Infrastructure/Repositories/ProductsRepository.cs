using DevStore.Products.Domain.Interfaces.Repositories;
using DevStore.Products.Domain.Models.Entities;
using DevStore.Products.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Infrastructure.Repositories
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(ProductsDbContext context) : base(context)
        {
        }
    }
}
