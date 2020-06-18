using System.Collections.Generic;
using Prime.Account.Data.Core;
using Prime.Account.Data.Repositories.Generics;

namespace Prime.Account.Data.Repositories.Interfaces
{
    public interface IBusinessEntityRepository : IRepository<BusinessEntity>
    {
        IEnumerable<BusinessEntity> GetBusinessEntity(int pageIndex, int pageSize);

        BusinessEntity GetBusinessEntityByUsername(string username);
    }
}
