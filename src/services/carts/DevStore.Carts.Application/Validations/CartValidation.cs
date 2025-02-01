using DevStore.Carts.Application.Commands;
using DevStore.Core.Models.Validations;
using FluentValidation;

namespace DevStore.Carts.Application.Validations
{
    public class CartValidation<T> : AbstractValidator<T> where T : CartCommand
    {
        public CartValidation()
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

            RuleFor(x => x.UserId)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

        }

    }
}
