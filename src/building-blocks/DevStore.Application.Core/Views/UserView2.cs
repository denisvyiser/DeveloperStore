using DevStore.Api.Core.ResponseModels;
using DevStore.Core.Models.ValueObjects;

namespace DevStore.Application.Core.Views
{
    public class UserView2 : ViewBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}
