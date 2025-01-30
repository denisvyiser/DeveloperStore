using DevStore.Core.Models.Validations;
using DevStore.Products.Application.Commands;
using FluentValidation;

namespace DevStore.Products.Application.Validations
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        public ProductValidation()
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

            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Price)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Description)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Category)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Image)
    .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

        }

    }
}

