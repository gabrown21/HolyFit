using Microsoft.AspNetCore.Components.Authorization;

namespace HolyFit.Helpers
{
    public static class AuthenticationStateProviderHelpers
    {
        public static async Task<UserModel> GetUserFromAuth(
      this AuthenticationStateProvider provider,
      IMongoUserData userData)
        {
            var authState = await provider.GetAuthenticationStateAsync();
            string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
            return await userData.GetUserFromAuthentication(objectId);
        }
    }
}
