using DevStore.Core.Interfaces.Commands;
using DevStore.Sales.Application.Validations;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Application.Commands
{
    public class AddSaleCommand : SaleCommand, IAddCommand
    {
        public AddSaleCommand(string branch, double totalAmount, AddSaleProductCommand saleProduct, Status status)
        {
            Branch = branch;
            TotalAmount = totalAmount;
            Status = status;
            SaleProduct = saleProduct;
        }

        public AddSaleProductCommand SaleProduct {  get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new SaleValidation<SaleCommand>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
