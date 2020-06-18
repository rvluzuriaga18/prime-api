using Prime.Account.Data.Core;
using Prime.Account.Data.Repositories.Interfaces;
using Prime.Account.Data.Repositories.Services;

namespace Prime.Account.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrimeDbContext _context;

        public UnitOfWork(PrimeDbContext context)
        {
            _context = context;

            BusinessEntity = new BusinessEntityRepository(_context);
            Person = new PersonRepository(_context);
            PersonAddress = new PersonAddressRepository(_context);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #region "Interfaces"

        public IBusinessEntityRepository BusinessEntity{ get; private set; }
        public IPersonRepository Person { get; private set; }
        public IPersonAddressRepository PersonAddress { get; private set; }
        
        #endregion
    }
}
