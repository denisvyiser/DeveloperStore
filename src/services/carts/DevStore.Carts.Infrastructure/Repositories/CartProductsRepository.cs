using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Carts.Infrastructure.Contexts;
using DevStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Carts.Infrastructure.Repositories
{
    public class CartProductsRepository : BaseRepository<CartProduct>, ICartProductsRepository
    {
        public CartProductsRepository(CartsDbContext context) : base(context)
        {
        }
    }
}
