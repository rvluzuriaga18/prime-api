using System.Configuration;

namespace Prime.Account.API.Helpers
{
    public static class ConfigHelper
    {
        public static string GetIssuer => ConfigurationManager.AppSettings["Issuer"];
        public static string GetSecretKey => ConfigurationManager.AppSettings["Secret"];
        public static string GetClientID => ConfigurationManager.AppSettings["ClientID"];
        public static string GetClientSecret => ConfigurationManager.AppSettings["ClientSecret"];
        public static string GetAudience => ConfigurationManager.AppSettings["Audience"];
        public static string GetEndpointPath => ConfigurationManager.AppSettings["EndpointPath"];
        public static string GetTokenExpireTimeSpan => ConfigurationManager.AppSettings["TokenExpireTimeSpan"];
        public static string GetAllowedOrigin => ConfigurationManager.AppSettings["AllowedOrigin"];
        public static string GetAuthType => ConfigurationManager.AppSettings["AuthenticationType"];
        public static string GetOAuthError => ConfigurationManager.AppSettings["OAuthError"];
        public static string GetOAuthErrorDesc => ConfigurationManager.AppSettings["OAuthErrorDescription"];
        public static string GetOAuthErrorStatCode => ConfigurationManager.AppSettings["OAuthResponseStatusCode"];
    }
}