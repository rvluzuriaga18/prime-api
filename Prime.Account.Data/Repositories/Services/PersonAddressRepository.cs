using Prime.Account.Data.Core;
using Prime.Account.Data.Repositories.Generics;
using Prime.Account.Data.Repositories.Interfaces;

namespace Prime.Account.Data.Repositories.Services
{
    public class PersonAddressRepository : Repository<PersonAddress>, IPersonAddressRepository
    {
        public PersonAddressRepository(PrimeDbContext context)
            : base(context)
        {
        }
    }
}
