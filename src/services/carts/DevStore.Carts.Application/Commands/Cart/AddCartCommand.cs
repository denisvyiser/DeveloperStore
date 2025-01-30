using DevStore.Carts.Application.Validations;
using DevStore.Carts.Domain.Models.Enums;
using DevStore.Core.Interfaces.Commands;

namespace DevStore.Carts.Application.Commands
{
    public class AddCartCommand : CartCommand, IAddCommand
    {
        public AddCartCommand(Guid userId, Status status)
        {
            UserId = userId;
            Status = status;
        }

        public override bool IsValid()
        {
            ValidationResult = new CartValidation<CartCommand>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
