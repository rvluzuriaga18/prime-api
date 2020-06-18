using System.Data.Entity;

namespace Prime.Account.Data.Core
{
    public partial class PrimeDbContext : DbContext
    {
        public PrimeDbContext()
            : base("name=PrimeDbContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonAddress> PersonAddresses { get; set; }
        public virtual DbSet<PersonAddressType> PersonAddressTypes { get; set; }
        public virtual DbSet<PersonCountryRegion> PersonCountryRegions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessEntity>()
                .HasOptional(e => e.Person)
                .WithRequired(e => e.BusinessEntity);

            modelBuilder.Entity<BusinessEntity>()
                .HasMany(e => e.PersonAddresses)
                .WithRequired(e => e.BusinessEntity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonAddressType>()
                .HasMany(e => e.PersonAddresses)
                .WithRequired(e => e.PersonAddressType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonCountryRegion>()
                .HasMany(e => e.PersonAddresses)
                .WithRequired(e => e.PersonCountryRegion)
                .WillCascadeOnDelete(false);
        }
    }
}
