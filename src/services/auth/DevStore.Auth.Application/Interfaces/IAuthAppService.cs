using DevStore.Auth.Application.Views;

namespace DevStore.Users.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task<LoginResponseView> Login(LoginRequestView request);

    }
}
