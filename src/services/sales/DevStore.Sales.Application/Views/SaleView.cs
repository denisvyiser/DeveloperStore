using DevStore.Api.Core.ResponseModels;
using DevStore.Sales.Domain.Moldes.Entities;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Application.Views
{
    public class SaleView : ViewBase
    {
        public Customer Customer { get; set; }
        public string Branch { get; set; }
        public double TotalAmount { get; set; }

        public List<SaleProduct> SaleProducts;
        public Status Status { get; set; }
    }
}
