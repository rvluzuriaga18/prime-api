using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime.Account.Data.Core
{
    [Table("PersonAddress")]
    public partial class PersonAddress
    {
        [Key]
        public int AddressId { get; set; }

        public long BusinessEntityId { get; set; }

        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; }

        [StringLength(60)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }

        public int AddressTypeId { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }

        public virtual PersonAddressType PersonAddressType { get; set; }

        public virtual PersonCountryRegion PersonCountryRegion { get; set; }
    }
}
