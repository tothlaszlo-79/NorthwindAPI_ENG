using Microsoft.AspNetCore.Authentication;

namespace NorthwindAPI.Auth
{
    public class ApiKeyAuthenticationOption : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "API Key";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;

    }
}
