using DevStore.Sales.Domain.Interfaces.Repositories;
using DevStore.Sales.Domain.Moldes.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Infrastructure.Repositories
{
    public class SaleProductsRepository : BaseRepository<SaleProduct>, ISaleProductsRepository
    {
        public SaleProductsRepository(DbContext context) : base(context)
        {
        }
    }
}
