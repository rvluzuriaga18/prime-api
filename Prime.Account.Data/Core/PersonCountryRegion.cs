using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime.Account.Data.Core
{
    [Table("PersonCountryRegion")]
    public partial class PersonCountryRegion
    {
        public PersonCountryRegion()
        {
            PersonAddresses = new HashSet<PersonAddress>();
        }

        [Key]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
    }
}
