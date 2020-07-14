using System;
using log4net;
using System.Linq;
using System.Net;
using System.Web.Http;
using Prime.Account.Data.UnitOfWork;
using Prime.Account.Data.Core;
using Prime.Account.API.Helpers;
using Prime.Account.API.Models;
using AesCrypto;

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
        /// Retrieve all users.
        /// </summary>
        [Route("api/User/GetUserList")]
        public IHttpActionResult GetUserList()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new PrimeDbContext()))
                {
                    var data = unitOfWork.Person.GetAll();
                    var result = DataFormatterHelper.RemoveReferenceLooping(data);

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

        /// <summary>
        /// Update user in Prime.
        /// </summary>
        [HttpPost]
        [Route("api/User/Update")]
        public IHttpActionResult Update(BusinessEntity request)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new PrimeDbContext()))
                {
                    var businessEntity = unitOfWork.BusinessEntity.GetBusinessEntityByUsername(request.Username);

                    businessEntity.Password = EncryptorDecryptor.Encrypt(request.Password);
                    businessEntity.Person = new Person()
                    {
                        Title = request.Person.Title,
                        FirstName = request.Person.FirstName,
                        MiddleName = request.Person.MiddleName,
                        LastName = request.Person.LastName,
                        Suffix = request.Person.Suffix,
                        Age = request.Person.Age
                    };

                    var pa = request.PersonAddresses.FirstOrDefault();
                    businessEntity.PersonAddresses.FirstOrDefault().AddressLine1 = pa.AddressLine1;
                    businessEntity.PersonAddresses.FirstOrDefault().AddressLine2 = pa.AddressLine2;
                    businessEntity.PersonAddresses.FirstOrDefault().City = pa.City;
                    businessEntity.PersonAddresses.FirstOrDefault().PostalCode = pa.PostalCode;
                    businessEntity.PersonAddresses.FirstOrDefault().CountryRegionCode = pa.CountryRegionCode;
                    businessEntity.PersonAddresses.FirstOrDefault().AddressTypeId = pa.AddressTypeId;

                    unitOfWork.SaveChanges();

                    return Ok(new OperationResult());
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return Content(HttpStatusCode.InternalServerError,
                    new OperationResult() { IsSuccess = false, Message = e.ToString() });
            }
        }
    }
}