using System;
using log4net;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using Prime.Account.Data.UnitOfWork;
using Prime.Account.Data.Core;
using Prime.Account.API.Helpers;

namespace Prime.Account.API.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Retrieve user identity.
        /// </summary>
        [Route("api/User/GetUserIdentity")]
        public HttpResponseMessage GetUserIdentity()
        {
            try
            {
                var username = User.Identity.Name;

                using (var unitOfWork = new UnitOfWork(new PrimeDbContext()))
                {
                    var data = unitOfWork.BusinessEntity.GetBusinessEntityByUsername(username);
                    var result = DataFormatterHelper.RemoveReferenceLooping(data);
                    result.Password = null;

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}