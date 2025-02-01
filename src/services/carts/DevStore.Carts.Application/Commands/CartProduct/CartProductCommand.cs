using DevStore.Core.Mediatr.Commands;

namespace DevStore.Carts.Application.Commands
{
    public abstract class CartProductCommand : Command
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Guid CartId { get; set; }

    }
}
