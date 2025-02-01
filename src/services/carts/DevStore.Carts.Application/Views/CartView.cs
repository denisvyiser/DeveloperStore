using DevStore.Api.Core.ResponseModels;
using DevStore.Carts.Domain.Models.Enums;

namespace DevStore.Carts.Application.Views
{
    public class CartView : ViewBase
    {
        public Guid UserId { get; set; }
        public Status Status { get; set; } = Status.Open;
        public List<CartProductView> CartProduct { get; set; } = new List<CartProductView>();
    }
}