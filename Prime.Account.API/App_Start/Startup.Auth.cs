using System;
using Owin;
using System.Configuration;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Prime.Account.API.OAuth;

namespace Prime.Account.API
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["Issuer"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["Secret"]);
            var audience = ConfigurationManager.AppSettings["Audience"];
            var endpointPath = ConfigurationManager.AppSettings["EndpointPath"];
            var tokenExpireTimeSpan = int.Parse(ConfigurationManager.AppSettings["TokenExpireTimeSpan"]);

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