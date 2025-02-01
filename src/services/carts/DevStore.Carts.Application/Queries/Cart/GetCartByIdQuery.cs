using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Mediatr.Queries;
using System.Linq.Expressions;

namespace DevStore.Carts.Application.Queries
{
    public class GetCartByIdQuery : GetQuery<Cart>
    {
        public GetCartByIdQuery() {

            Properties = new Expression<Func<Cart, object>>[] {c=> c.CartProduct };
        }
    }
}
