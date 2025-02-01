using DevStore.Api.Core.ResponseModels;

namespace DevStore.Carts.Application.Views
{
    public class CartProductView : ViewBase
    {
        public Guid ProductId { get;  set; }
        public string ProductTitle { get;  set; }
        public string ProductImage { get;  set; }
        public int Quantity { get;  set; }
        public double UnitPrice { get;  set; }
        public Guid CartId { get;  set; }

    }
}
