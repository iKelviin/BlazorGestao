using Gestao.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Gestao.Client.Libraries.Helpers
{
    public class AuthenticationHelper
    {
        public static async Task<Guid?> GetAuthenticationUserIdAsync(AuthenticationStateProvider provider)
        {
            var authenticationState = await provider.GetAuthenticationStateAsync();
            var userId = authenticationState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);


            if (userId != null && Guid.TryParse(userId.Value, out var ApplicationUserId))
            {
                return ApplicationUserId;
            }
            return null;
        }
    }
}
