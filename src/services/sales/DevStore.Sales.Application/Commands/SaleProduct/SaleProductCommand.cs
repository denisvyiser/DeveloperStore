using DevStore.Core.Mediatr.Commands;
using DevStore.Sales.Domain.Moldes.Entities;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Application.Commands
{
    public abstract class SaleProductCommand : Command
    {
        public Guid ProductId { get; protected set; }
        public string ProductTitle { get; protected set; }
        public string ProductImage { get; protected set; }
        public int Quantity { get; protected set; }
        public double UnitPrice { get; protected set; }
        public double Discount { get; protected set; }
        public Guid SaleId { get; protected set; }
        public Sale Sale { get; protected set; }
        public Status Status { get; protected set; }
    }
}
