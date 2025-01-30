using DevStore.Core.Models.Entities;
using System.Linq.Expressions;

namespace DevStore.Core.Mediatr.Queries
{
    public class GetQuery<TEntity> : Query<TEntity> where TEntity : Entity
    {
        public Guid Id { get; set; }

        public Expression<Func<TEntity, object>>[] Properties;

        public override bool IsValid()
        {
            return Id != Guid.Empty;
        }
    }
}