using DevStore.Api.Core.ResponseModels;

namespace DevStore.Sales.Application.Views
{
    public class SaleProductView : ViewBase
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public Guid SaleId { get; set; }
        public string Status { get; set; }
    }
}
