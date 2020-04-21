using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Prime.Account.API.App_Start
{
    public class BasicAuth
    {
        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    if (actionContext.Request.Headers.Authorization == null)
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //    else
        //    {
        //        var authToken = actionContext.Request.Headers.Authorization.Parameter;
        //        var decodeAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

        //        var userPass = decodeAuthToken.Split(':');

        //        if (!IsAuthorizedUser(userPass[0], userPass[1]))
        //            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        else
        //            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userPass[0]), null);
        //    }
        //}

        //public static bool IsAuthorizedUser(string username, string password)
        //{
        //    return username == "sa" && password == "Ch3ck1t{}";
        //}
    }
}