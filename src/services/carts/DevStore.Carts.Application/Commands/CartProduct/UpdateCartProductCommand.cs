using DevStore.Carts.Application.Validations;
using DevStore.Core.Interfaces.Commands;

namespace DevStore.Carts.Application.Commands
{
    public class UpdateCartProductCommand : CartProductCommand, IUpdateCommand
    {
        public UpdateCartProductCommand(Guid id, Guid productId, string productTitle, string productImage, int quantity, double unitPrice, Guid cartId)
        {
            Id = id;
            ProductId = productId;
            ProductTitle = productTitle;
            ProductImage = productImage;
            Quantity = quantity;
            UnitPrice = unitPrice;
            CartId = cartId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CartProductValidation<CartProductCommand>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
