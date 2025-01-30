using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Pagination;
using System.Linq.Expressions;

namespace DevStore.Core.Mediatr.Queries
{
    public abstract class GetPaginatedQuery<TEntity> : Query<PaginatedList<TEntity>> where TEntity : Entity
    {
        public List<Filter> Filters { get; set; } = new List<Filter>();
        public Page Page { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Expression<Func<TEntity, object>>[] Properties;
        //public Restriction Restriction { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}