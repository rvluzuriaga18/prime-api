using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace Prime.Account.API.OAuth
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private string _clientId;
        private string _clientSecret;
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                context.TryGetFormCredentials(out _clientId, out _clientSecret);

                if(_clientId == "clientId101" && _clientSecret == "clientSecret101")
                       context.Validated(_clientId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var allowedOrigin = ConfigurationManager.AppSettings["AllowedOrigin"];
                var authenticationType = ConfigurationManager.AppSettings["AuthenticationType"];
                var oauthError = ConfigurationManager.AppSettings["OAuthError"];
                var oAuthErrorDesc = ConfigurationManager.AppSettings["OAuthErrorDescription"];
                var oAuthErrorStatusCode = ConfigurationManager.AppSettings["OAuthResponseStatusCode"];

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

                if (!IsAuthorizedUser(context.UserName, context.Password))
                {
                    context.SetError(oauthError, oAuthErrorDesc);
                    context.Response.StatusCode = int.Parse(oAuthErrorStatusCode);
                    context.Rejected();
                }
                else
                {
                    var oAuthIdentity = new ClaimsIdentity(authenticationType);
                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                    var actor = _clientId;
                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Actor, actor));

                    var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
                    context.Validated(ticket);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return Task.FromResult<object>(null);

            //return base.GrantResourceOwnerCredentials(context);
        }

        public static bool IsAuthorizedUser(string username, string password)
        {
            return username == "sa" && password == "Ch3ck1t{}";
        }
    }
}