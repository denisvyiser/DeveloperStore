using DevStore.Core.Models.Entities;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Domain.Moldes.Entities
{
    public class SaleProduct : Entity
    {
        public SaleProduct(Guid id, Guid productId, string productTitle, string productImage, int quantity, double unitPrice, double discount, Guid saleId, Status status)
        {
            Id = id;
            ProductId = productId;
            ProductTitle = productTitle;
            ProductImage = productImage;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            SaleId = saleId;
            Status = status;
        }

        public Guid ProductId { get; private set; }
        public string ProductTitle { get; private set; }
        public string ProductImage { get; private set; }
        public int Quantity { get; private set; }
        public double UnitPrice { get; private set; }
        public double Discount { get; private set; }
        public Guid SaleId { get; private set; }
        public Sale Sale { get; private set; }
        public Status Status { get; private set; }

        public void SetDiscount(double discount)
        {
            Discount = discount;
        }

    }

}
