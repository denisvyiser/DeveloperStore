using DevStore.Core.Interfaces.Aggregates;
using DevStore.Core.Models.Entities;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Domain.Moldes.Entities
{
    public class Sale : Entity, IAggregateRoot
    {
        public Sale(Guid id, string branch, double totalAmount, Status status)
        {
            Id = id;
            Branch = branch;
            TotalAmount = totalAmount;
            Status = status;
        }
        public Customer Customer { get; private set; }
        public string Branch { get; private set; }
        public double TotalAmount { get; private set; }

        public List<SaleProduct> SaleProduct { get; set; } = new List<SaleProduct>();
        public Status Status { get; set; }

        public void ApplyDiscount()
        {
            foreach (var item in SaleProduct)
            {
                var discount = item.UnitPrice - (DiscountRules(item.Quantity) * item.UnitPrice);

                item.SetDiscount(discount);
            }
        }

        private double DiscountRules(int quantity)
        {  
            if (quantity > 4 && quantity < 10)
                return 0.10;
            if (quantity >= 10 && quantity <= 20)
                return 0.20;
            else 
                return 0;
        }

        public void SetTotalAmount()
        {
            TotalAmount = SaleProduct.Select(c => (c.UnitPrice * c.Quantity) - c.Discount).Sum();
        }


    }
}
