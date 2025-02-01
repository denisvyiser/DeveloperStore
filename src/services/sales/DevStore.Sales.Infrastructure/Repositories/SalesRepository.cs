using DevStore.Sales.Domain.Interfaces.Repositories;
using DevStore.Sales.Domain.Moldes.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Infrastructure.Repositories
{
    public class SalesRepository : BaseRepository<Sale>, ISalesRepository
    {
        public SalesRepository(DbContext context) : base(context)
        {
        }
    }
}
