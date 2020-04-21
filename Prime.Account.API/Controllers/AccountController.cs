using System.Web.Http;
using System.Collections.Generic;

namespace Prime.Account.API.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        public IEnumerable<string> GetPersonalInfo()
        {
            return new string[] { "Personal Info 1", "Personal Info 2" };
        }
    }
}