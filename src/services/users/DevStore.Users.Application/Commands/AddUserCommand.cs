using DevStore.Core.Interfaces.Commands;
using DevStore.Core.Models.ValueObjects;
using DevStore.Users.Application.Validations;
using DevStore.Users.Domain.Models.Enums;

namespace DevStore.Users.Application.Commands
{
    public class AddUserCommand : UserCommand, IAddCommand
    {
        public AddUserCommand(string email, string userName, string password, Name name, Address address, string phone, Status status, Role role)
        {
            Email = email;
            UserName = userName;
            Password = password;
            Name = name;
            Address = address;
            Phone = phone;
            Status = status;
            Role = role;
        }
        public override bool IsValid()
        {
            ValidationResult = new UserValidation<UserCommand>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
