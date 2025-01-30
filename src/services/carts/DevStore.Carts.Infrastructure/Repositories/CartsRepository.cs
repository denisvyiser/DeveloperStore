using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Carts.Infrastructure.Contexts;
using DevStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Carts.Infrastructure.Repositories
{
    public class CartsRepository : BaseRepository<Cart>, ICartsRepository
    {
        public CartsRepository(CartsDbContext context) : base(context)
        {
        }
    }
}
