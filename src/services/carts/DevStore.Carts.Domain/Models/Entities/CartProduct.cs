using DevStore.Core.Models.Entities;
using System.Text.Json.Serialization;

namespace DevStore.Carts.Domain.Models.Entities
{
    public class CartProduct : Entity
    {
        public CartProduct(Guid id, Guid productId, string productTitle, string productImage, int quantity, double unitPrice, Guid cartId)
        {
            Id = id;
            ProductId = productId;
            ProductTitle = productTitle;
            ProductImage = productImage;
            Quantity = quantity;
            UnitPrice = unitPrice;
            CartId = cartId;
        }

        public Guid ProductId { get; private set; }
        public string ProductTitle { get; private set; }
        public string ProductImage { get; private set; }
        public int Quantity { get; private set; }
        public double UnitPrice { get; private set; }
        public Guid CartId { get; private set; }

        [JsonIgnore]
        public Cart Cart { get; private set; }
    }
}
