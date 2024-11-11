using Microsoft.AspNetCore.Authentication;
using NorthwindAPI.Auth;

namespace NorthwindAPI.Extensions
{
    public static class AuthExtension
    {
        public static AuthenticationBuilder AddApiKeySupport
            (this AuthenticationBuilder builder, Action<ApiKeyAuthenticationOption> option)
        { 
            return builder.AddScheme
                <ApiKeyAuthenticationOption, ApiAuthenticationHandler>
                (ApiKeyAuthenticationOption.DefaultScheme, option);
        
        }
    }
}
