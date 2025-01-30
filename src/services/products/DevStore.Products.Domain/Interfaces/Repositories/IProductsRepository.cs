using DevStore.Core.Interfaces;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Domain.Interfaces.Repositories
{
    public interface IProductsRepository : IBaseRepository<Product>
    {
    }
}
