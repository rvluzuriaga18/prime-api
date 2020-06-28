using System;
using log4net;
using System.Net;
using System.Web.Http;
using Prime.Account.Data.UnitOfWork;
using Prime.Account.Data.Core;
using Prime.Account.API.Helpers;
using Prime.Account.API.Models;
using AesCrypto;
using System.Linq;

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
        public IHttpActionResult GetUserIdentity()
        {
            try
            {
                var username = User.Identity.Name;

                using (var unitOfWork = new UnitOfWork(new PrimeDbContext()))
                {
                    var data = unitOfWork.BusinessEntity.GetBusinessEntityByUsername(username);
                    var result = DataFormatterHelper.RemoveReferenceLooping(data);
                    result.Password = null;

                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Register user in Prime.
        /// </summary>
        [HttpPost]
        [Route("api/User/Register")]
        public IHttpActionResult Register(BusinessEntity request)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new PrimeDbContext()))
                {
                    var businessEntityUser = unitOfWork.BusinessEntity
                                                     .Find(user => user.Username.Equals(request.Username,
                                                      StringComparison.InvariantCultureIgnoreCase))
                                                     .FirstOrDefault()?.Username;

                    if (!string.IsNullOrEmpty(businessEntityUser))
                        return Ok(new OperationResult() 
                        {
                            IsSuccess = false,
                            Message = "Username already exists."
                        });

                    var be = new BusinessEntity()
                    {
                        CreatedOn = DateTime.Now,
                        Username = request.Username,
                        Password = EncryptorDecryptor.Encrypt(request.Password)
                    };

                    be.Person = request.Person;
                    be.PersonAddresses = request.PersonAddresses;

                    unitOfWork.BusinessEntity.Add(be);
                    unitOfWork.SaveChanges();

                    return Ok(new OperationResult());
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return Content(HttpStatusCode.InternalServerError,
                    new OperationResult() { IsSuccess = false, Message = e.ToString()});
            }
        }
    }
}