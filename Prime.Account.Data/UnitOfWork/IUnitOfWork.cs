using System;
using Prime.Account.Data.Repositories.Interfaces;

namespace Prime.Account.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBusinessEntityRepository BusinessEntity { get; }
        IPersonRepository Person { get; }
        IPersonAddressRepository PersonAddress { get; }
        int SaveChanges();
    }
}
