using Microsoft.AspNetCore.Http;

namespace DevStore.Core.Authentication.Identity
{
    public class UserIdentity
    {
        private readonly IHttpContextAccessor _accessor;

        public UserIdentity(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid GetUserId()
        {
            return Guid.Parse("");
        }
    }
}
