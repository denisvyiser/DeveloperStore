using DevStore.Api.Core.ResponseModels;
using DevStore.Core.Models.ValueObjects;
using DevStore.Users.Domain.Models.Enums;

namespace DevStore.Users.Application.Views
{
    public class UserView : ViewBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}
