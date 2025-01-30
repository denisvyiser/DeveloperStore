using DevStore.Carts.Application.Commands;
using DevStore.Core.Models.Validations;
using FluentValidation;

namespace DevStore.Carts.Application.Validations
{
    public class CartProductValidation<T> : AbstractValidator<T> where T : CartProductCommand
    {
        public CartProductValidation()
        {
            Validate();
        }

        protected void Validate()
        {
            var type = typeof(T).Name;
            RuleFor(x => x.Id)
                .Custom((id, context) =>
                {
                    if (type.StartsWith("Update"))
                        if (id == Guid.Empty)
                            context.AddFailure("The Id is required.");
                });

            RuleFor(x => x.ProductId)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.ProductTitle)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.ProductImage)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Quantity)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.UnitPrice)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.CartId)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);
        }

    }
}
