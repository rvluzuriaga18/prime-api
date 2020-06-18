using System.Linq;
using System.Collections.Generic;
using Prime.Account.Data.Core;
using Prime.Account.Data.Repositories.Generics;
using Prime.Account.Data.Repositories.Interfaces;
using System.Data.Entity;

namespace Prime.Account.Data.Repositories.Services
{
    public class BusinessEntityRepository : Repository<BusinessEntity>, IBusinessEntityRepository
    {
        public BusinessEntityRepository(PrimeDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<BusinessEntity> GetBusinessEntity(int pageIndex, int pageSize)
        {
            return Context.BusinessEntities.AsNoTracking()
                          .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                          .ToList();
        }

        public BusinessEntity GetBusinessEntityByUsername(string username)
        {
            return Context.BusinessEntities.Include("Person")
                                           .Include("PersonAddresses")
                                           .Where(be => be.Username == username)
                                           .FirstOrDefault();
        }

        public PrimeDbContext Context => _context; 

    }
}
