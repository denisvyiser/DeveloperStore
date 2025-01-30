using DevStore.Core.Mediatr.Commands;
using DevStore.Sales.Domain.Moldes.Entities;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Application.Commands
{
    public abstract class SaleCommand : Command
    {
        public Customer Customer { get; set; }
        public string Branch { get; set; }
        public double TotalAmount { get; set; }
        public Status Status { get; set; }
    }
}
