using Prime.Account.Data.Core;
using Prime.Account.Data.Repositories.Generics;
using Prime.Account.Data.Repositories.Interfaces;

namespace Prime.Account.Data.Repositories.Services
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PrimeDbContext context)
            : base(context)
        {
        }
    }
}
