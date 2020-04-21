using System;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.OAuth;
using Prime.Account.API.OAuth;
using Prime.Account.API.Helpers;

namespace Prime.Account.API
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigHelper.GetIssuer;
            var secret = TextEncodings.Base64Url.Decode(ConfigHelper.GetSecretKey);
            var audience = ConfigHelper.GetAudience;
            var endpointPath = ConfigHelper.GetEndpointPath;
            var tokenExpireTimeSpan = int.Parse(ConfigHelper.GetTokenExpireTimeSpan);

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience }, 
                IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                {
                    new SymmetricKeyIssuerSecurityKeyProvider(issuer, secret)
                }
            });

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer),
                TokenEndpointPath = new PathString(endpointPath),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(tokenExpireTimeSpan),
                AllowInsecureHttp = false
            });
        }
    }
}