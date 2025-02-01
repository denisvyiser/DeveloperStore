using DevStore.Core.Models.Validations;
using DevStore.Users.Application.Commands;
using FluentValidation;

namespace DevStore.Users.Application.Validations
{
    public class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        public UserValidation()
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

            RuleFor(x => x.Email)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.UserName)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Name)
                .Must(c => !string.IsNullOrWhiteSpace(c.FirstName) && !string.IsNullOrWhiteSpace(c.LastName))
                .WithMessage(ValidationMessages.NotNullMessage);

            RuleFor(x => x.Address)
                .Must(c => !string.IsNullOrWhiteSpace(c.Number) && !string.IsNullOrWhiteSpace(c.City) &&
                !string.IsNullOrWhiteSpace(c.ZipCode) && c.Geolocation.Longitude > 0 && c.Geolocation.Latitude > 0)
                .WithMessage(ValidationMessages.NotNullMessage);

        }

    }
}
