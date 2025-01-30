using System.Linq.Expressions;

namespace DevStore.Core.Mediatr.Queries
{
    public class GetByQuery<TEntity> : Query<List<TEntity>>
    {
        public Expression<Func<TEntity, bool>> Filter { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}