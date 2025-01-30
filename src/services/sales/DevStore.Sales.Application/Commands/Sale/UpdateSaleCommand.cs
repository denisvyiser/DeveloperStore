using DevStore.Core.Interfaces.Commands;
using DevStore.Sales.Application.Validations;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Application.Commands
{
    public class UpdateSaleCommand : SaleCommand, IUpdateCommand
    {
        public UpdateSaleCommand(Guid id, string branch, double totalAmount, UpdateSaleProductCommand saleProduct, Status status)
        {
            Id = id;
            Branch = branch;
            TotalAmount = totalAmount;
            Status = status;
            SaleProduct = saleProduct;
        }

        public UpdateSaleProductCommand SaleProduct { get; private set; }
        public override bool IsValid()
        {
            ValidationResult = new SaleValidation<SaleCommand>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
