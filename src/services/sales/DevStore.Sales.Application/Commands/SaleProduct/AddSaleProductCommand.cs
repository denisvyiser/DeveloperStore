using DevStore.Core.Interfaces.Commands;
using DevStore.Sales.Application.Validations;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Application.Commands
{
    public class AddSaleProductCommand : SaleProductCommand, IAddCommand
    {
        public AddSaleProductCommand(Guid productId, string productTitle, string productImage, int quantity, double unitPrice, double discount, Guid saleId, Status status)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            ProductImage = productImage;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            SaleId = saleId;
            Status = status;
        }

        public override bool IsValid()
        {
            ValidationResult = new SaleProductValidation<SaleProductCommand>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
