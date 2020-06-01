using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Prime.Account.API.Helpers;
using AesCrypto;
using log4net;

namespace Prime.Account.API.OAuth
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _clientId;
        private string _clientSecret;
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                context.TryGetFormCredentials(out _clientId, out _clientSecret);

                var clientId = EncryptorDecryptor.Decrypt(ConfigHelper.GetClientID);
                var clientSecret = EncryptorDecryptor.Decrypt(ConfigHelper.GetClientSecret);

                if(_clientId == clientId && _clientSecret == clientSecret)
                       context.Validated(_clientId);
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
            }

            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var allowedOrigin = ConfigHelper.GetAllowedOrigin;
                var authenticationType = ConfigHelper.GetAuthType;
                var oauthError = ConfigHelper.GetOAuthError;
                var oAuthErrorDesc = ConfigHelper.GetOAuthErrorDesc;
                var oAuthErrorStatusCode = ConfigHelper.GetOAuthErrorStatCode;

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
                _logger.Error(e.ToString());
            }

            return Task.FromResult<object>(null);

            //return base.GrantResourceOwnerCredentials(context);
        }

        public static bool IsAuthorizedUser(string username, string password)
        {
            var user = EncryptorDecryptor.Decrypt(ConfigHelper.GetUsername);
            var pass = EncryptorDecryptor.Decrypt(ConfigHelper.GetPassword);

            return username == user && password == pass;
        }
    }
}