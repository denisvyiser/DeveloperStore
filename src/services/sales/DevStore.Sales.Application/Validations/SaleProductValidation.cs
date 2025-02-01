using DevStore.Core.Models.Validations;
using DevStore.Sales.Application.Commands;
using FluentValidation;

namespace DevStore.Sales.Application.Validations
{
    public class SaleProductValidation<T> : AbstractValidator<T> where T : SaleProductCommand
    {
        public SaleProductValidation()
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
                .Must(c => c == Guid.Empty)
                .WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.ProductTitle)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.ProductImage)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.GreaterThanMessage);

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.GreaterThanMessage);

            RuleFor(x => x.SaleId)
                .Must(c => c == Guid.Empty)
                .WithMessage(ValidationMessages.NotNullMessage);

        }

    }
}
