using DevStore.Core.Models.Validations;
using DevStore.Sales.Application.Commands;
using FluentValidation;

namespace DevStore.Sales.Application.Validations
{
    public class SaleValidation<T> : AbstractValidator<T> where T : SaleCommand
    {
        public SaleValidation()
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

            RuleFor(x => x.Branch)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanMessage);

            RuleFor(x => x.Customer.CustomerName)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Customer.CustomerId)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            
        }

    }
}
