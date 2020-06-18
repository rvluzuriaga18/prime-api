using System;
using log4net;
using System.Linq;
using Prime.Account.Data.Core;
using Prime.Account.Data.UnitOfWork;
using AesCrypto;

namespace Prime.Account.API.Helpers
{
    public static class UserAuthHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool AuthenticateUser(string username, string password)
        {
            try
            {
                var userPassword = string.Empty;

                using (var unitOfWork = new UnitOfWork(new PrimeDbContext()))
                {
                    var userDetails = unitOfWork.BusinessEntity.Find(x => x.Username == username)
                                      .FirstOrDefault();

                    if (userDetails == null) return false;

                    userPassword = EncryptorDecryptor.Decrypt(userDetails.Password);
                }

                return (password == userPassword);
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return false;
            }
        }
    }
}